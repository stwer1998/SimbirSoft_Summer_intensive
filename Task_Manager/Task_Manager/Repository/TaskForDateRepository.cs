using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class TaskForDateRepository : ITaskForDateRepository
    {
        private MyDbContext db;
        private IScheduleRepository schedule;
        public TaskForDateRepository(MyDbContext db, IScheduleRepository schedule)
        {
            this.db = db;
            this.schedule = schedule;
        }

        public List<TaskForDate> GetTodayTaskForUser(int childId)
        {
            return db.TaskForDates.Include(x=>x.TaskElement)
                .Where(x => x.DateOfTask == DateTime.Now.Date 
                && x.StatusTask!=Status.Done
                &&x.ChildId==childId)
                .ToList();
        }

        public void MarkDoneTasksChild(int childId, int[] idtaskarray)
        {
            var tasks = db.TaskForDates.Where(x => x.DateOfTask == DateTime.Now.Date && x.StatusTask != Status.Done);
            for (int i = 0; i < idtaskarray.Count(); i++)
            {
                tasks.FirstOrDefault(x => x.TaskForDateId == idtaskarray[i]).StatusTask = Status.Done;
            }
            db.SaveChanges();
        }

        public void UpdeteScheduleChild(int childId)
        {

            if (db.Childs.FirstOrDefault(x => x.ChildId == childId).UpdateDate >= DateTime.Now.Date)
            {

            }
            else if (db.Childs.FirstOrDefault(x => x.ChildId == childId).UpdateDate == DateTime.Now.Date.AddDays(-1))
            {
                var tasks = new List<TaskElement>();
                tasks=GetTaskForToday(childId);

                foreach (var item in tasks)
                {
                    db.TaskForDates.Add(
                            new TaskForDate()
                            {
                                DateOfTask = DateTime.Now.Date,
                                StatusTask = Status.Schedule,
                                TaskElement = item,
                                ChildId = childId
                            });
                    db.TaskElements
                        .FirstOrDefault(x=>x.TaskElementId==item.TaskElementId)
                        .Point= DateTime.Now.Date.AddDays(item.Periodicity);
                   
                }
                db.SaveChanges();
                tasks = GetMissedTasks(childId);

                foreach (var item in tasks)
                {
                    db.TaskForDates.Add(
                            new TaskForDate()
                            {
                                DateOfTask = DateTime.Now.Date,
                                StatusTask = Status.Missed,
                                TaskElement = item,
                                ChildId = childId
                            });
                    var task = db.TaskForDates
                        .FirstOrDefault(x => x.DateOfTask == DateTime.Now.Date.AddDays(-1) && x.TaskElement == item);
                    if (task != null)
                    {
                        db.TaskForDates
                            .Remove(task);
                    }
                }
                db.Childs.FirstOrDefault(x => x.ChildId == childId).UpdateDate = DateTime.Now.Date;
                db.SaveChanges();

            }
            else
            {
                var date = db.Childs.FirstOrDefault(x => x.ChildId == childId).UpdateDate;
                db.TaskForDates.AddRange(schedule.GetSchedule(childId,date,DateTime.Now.Date));
            }
        }
     
        private List<TaskElement> GetTaskForToday(int childId)
        {
           var tasks= db.TaskElements.
                Where(x => x.ChildId == childId&&
                x.Point==DateTime.Now.Date).
                ToList();
            var result = new List<TaskElement>();

            foreach (var item in tasks)
            {
                var task = db.TaskForDates.FirstOrDefault(
                    x=>x.ChildId==childId
                    &&x.DateOfTask==DateTime.Now.Date
                    &&x.TaskElement==item);
                if (task==null)
                {
                    result.Add(item);
                }
            }

            return result;         
        }

        private List<TaskElement> GetMissedTasks(int childId)
        {
            var tasks= db.TaskForDates.Where(x => x.ChildId == childId
            && x.DateOfTask == DateTime.Now.Date.AddDays(-1)
            && x.StatusTask != Status.Done)
            .Include(x => x.TaskElement)
            .Select(x => x.TaskElement)
            .ToList();

            var result = new List<TaskElement>();

            foreach (var item in tasks)
            {
                var task=db.TaskForDates.FirstOrDefault(x => x.ChildId == childId
                && x.DateOfTask == DateTime.Now.Date
                && x.TaskElement == item);

                if (task==null)
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
