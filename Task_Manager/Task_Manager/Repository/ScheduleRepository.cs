using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private MyDbContext db;
        public ScheduleRepository(MyDbContext db)
        {
            this.db = db;
        }

        public List<TaskForDate> GetSchedule(int childId, DateTime startdate, DateTime endate)
        {
            var result = new List<TaskForDate>();
            result.AddRange(GetArchiveDates(childId,startdate,endate));
            result.AddRange(PlaningSchedule(childId, startdate, endate));
            return result;
        }

        public List<List<string>> GetTable(int childId, DateTime startdate, DateTime endate)
        {
            var result = new List<List<string>>();
            var tasks = GetSchedule(childId,startdate,endate);
            result.Add(new List<string>());
            result[0].Add(" ");
            for (DateTime i = startdate.Date; i < endate.Date; i=i.AddDays(1))
            {
                result[0].Add(i.Date.ToString());
            }
            var r = tasks.Select(x => x.TaskElement).Distinct().ToList();
            for (int i = 0; i < r.Count; i++)
            {
                result.Add(new List<string>());
                result[i + 1].Add(r[i].TaskName + " " + r[i].TaskCategory);
                for (int j = 1; j < result[0].Count; j++)
                {
                    result[i + 1].Add(string.Empty);
                }
            }
            foreach (var item in tasks)
            {
                var y = r.IndexOf(item.TaskElement)+1;
                var a = item.DateOfTask.Date.ToString();
                var x = result[0].IndexOf(a);
                result[y][x] = "+";
            }


            return result;
        }

        private List<TaskForDate> GetArchiveDates(int childId, DateTime startdate, DateTime endate)
        {
            var result = new List<TaskForDate>();
            result.AddRange(db.TaskForDates.Include(x=>x.TaskElement).Where(x=>x.ChildId==childId
            &&x.DateOfTask<endate
            &&x.DateOfTask>startdate));
            return result;
        }

        private List<TaskForDate> PlaningSchedule(int childId, DateTime startdate, DateTime endate)
        {
            var result = new List<TaskForDate>();
            var tasks = db.TaskElements.Where(x => x.ChildId == childId).ToList();
            while (startdate < endate)
            {
                foreach (var item in tasks)
                {
                    if (item.Point == startdate)
                    {
                        result.Add(new TaskForDate()
                        {
                            ChildId=childId,
                            DateOfTask=startdate,
                            TaskElement=item,
                            StatusTask=Status.Schedule
                        });
                        item.Point = startdate.Date.AddDays(item.Periodicity);
                    }
                }
                startdate=startdate.AddDays(1);
            }
            return result;
        }
    }
}
