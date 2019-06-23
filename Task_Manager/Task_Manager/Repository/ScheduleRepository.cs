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
