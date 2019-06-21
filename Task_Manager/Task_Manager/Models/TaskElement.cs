using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class TaskElement
    {
        public int TaskElementId { get; set; }
        public string TaskCategory { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public int Periodicity { get; set; }
        public int ChildId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Point { get; set; }
    }
}
