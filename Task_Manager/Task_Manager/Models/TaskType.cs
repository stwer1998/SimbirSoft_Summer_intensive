using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_Manager.Models
{
    public class TaskType
    {
        public int TaskTypeId { get; private set; }
        public string Name { get ; set ; }
        public List<TaskElement> TaskElements { get; set; }
    }
}
