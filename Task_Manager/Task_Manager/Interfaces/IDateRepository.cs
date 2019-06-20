using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface IDateRepository
    {
        void AddChild(string login, Child child);
        void AddTask(string login, TaskModel taskModel);
        void UpdateUserDate(string login);
        List<Child> GetTodayTasks(string login); 
    }
}
