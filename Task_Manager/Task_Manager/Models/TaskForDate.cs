using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class TaskForDate
    {
        public int TaskForDateId { get; private set; }
        public TaskElement TaskElement { get; set; }
        public DateTime Date { get; set; }
    }
}
