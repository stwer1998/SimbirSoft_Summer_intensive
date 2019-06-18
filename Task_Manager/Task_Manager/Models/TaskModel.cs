using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;

namespace Task_Manager
{
    public class TaskModel : ITaskElement
    {
        public int TaskId { get; private set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PointForCalculate { get; set; }
        public int Periodicity { get; set; }

        public DateTime NextDay()
        {
            return PointForCalculate.AddDays(Periodicity);
        }

        public void SetPointForCalculate()
        {
            PointForCalculate = DateTime.Now;
        }
    }
}
