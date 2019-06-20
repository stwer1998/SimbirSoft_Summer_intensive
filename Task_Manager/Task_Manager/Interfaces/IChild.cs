using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface IChild
    {
        string Name { get; set; }
        string Surname { get; set; }
        ICollection<ITaskType> Tasks { get; set; }
        ICollection<ITaskElement> MissedTasks { get; set; }
    }
}
