using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class DtoTable
    {
        public List<DateTime> Dates;
        public Dictionary<TaskElement, List<TaskForDate>> Dict;
    }
}
