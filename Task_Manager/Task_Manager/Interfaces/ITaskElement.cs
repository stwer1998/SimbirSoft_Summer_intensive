using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Interfaces
{
    public interface ITaskElement
    {
        string TaskName { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime PointForCalculate { get; set; }
        int Periodicity { get; set; }
        DateTime NextDay();
        void SetPointForCalculate();
    }
}
