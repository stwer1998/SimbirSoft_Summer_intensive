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
        public TaskForDateRepository(MyDbContext db)
        {
            this.db = db;
        }

        public List<TaskElement> GetTodayTaskForUser(int childId)
        {
            return db.TaskForDates
                .Where(x => x.DateOfTask == DateTime.Now.Date && x.IsDone == false)
                .Select(z=>z.TaskElement)
                .ToList();
        }

        public void MarkDoneTasksChild(int childId, int[] idtaskarray)
        {
            var tasks = db.TaskForDates.Where(x => x.DateOfTask == DateTime.Now.Date && x.IsDone == false);
            for (int i = 0; i < idtaskarray.Count(); i++)
            {
                tasks.FirstOrDefault(x => x.TaskForDateId == idtaskarray[i]).IsDone = true;
            }
            db.SaveChanges();
        }

        public void UpdeteScheduleChild(int childId)
        {
            var tasksForDates = new List<TaskForDate>();
            if (db.Childs.FirstOrDefault(x => x.ChildId == childId).UpdateDate == DateTime.Now.Date)
            {
                var tasks = db.TaskElements.Where(x => x.ChildId == childId).ToList();
                foreach (var item in tasks)
                {
                    var taskfordate = new TaskForDate()
                    {
                        ChildId = childId,
                        DateOfTask = DateTime.Now.Date,
                        IsDone = false,
                        TaskElement = item,
                        StatusTask="onschedule"
                    };
                    tasksForDates.Add(taskfordate);
                }
            }
            else
            {

            }
        }
    }
}
