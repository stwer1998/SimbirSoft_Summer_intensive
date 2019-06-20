using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;

namespace Task_Manager.Models
{
    public class TaskType:ITaskType
    {
        public int TaskTypeId { get;set;}
        public string TypeName { get; set; }
        public ICollection<ITaskElement> Tasks { get; set; }
    }
}
