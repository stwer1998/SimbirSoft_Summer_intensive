using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class DtoForIndex
    {
        public List<Child> Childs;
        public Dictionary<Child, List<TaskForDate>> TasksToday;
    }
}
