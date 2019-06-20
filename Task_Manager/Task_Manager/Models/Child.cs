using System.Collections.Generic;
using Task_Manager.Interfaces;

namespace Task_Manager.Models
{
    public class Child : IChild
    {
        public int ChildId { get; private set; }
        public string Name { get;  set; }
        public string Surname { get; set; }
        public ICollection<ITaskType> Tasks { get; set; }
        public ICollection<ITaskElement> MissedTasks { get;  set; }
    }
}
