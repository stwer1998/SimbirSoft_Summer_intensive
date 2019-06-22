using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class DtoModelChild
    {
        public int ChildId;
        public string ChildName;
        public string ChildSurName;
        public List<TaskElement> taskElements;
    }
}
