using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;

namespace Task_Manager
{
    public class ITaskType
    {
        string Name { get; set; }
        ICollection<ITaskElement> TaskElements { get; set; }
    }
}
