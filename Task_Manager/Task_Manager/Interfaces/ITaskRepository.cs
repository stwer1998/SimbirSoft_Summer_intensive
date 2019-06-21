using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    interface ITaskRepository
    {
        /// <summary>
        /// Добавление занятие
        /// </summary>
        /// <param name="taskElement"></param>
        void AddTask(TaskElement taskElement);
        /// <summary>
        /// Редактирование занятие
        /// </summary>
        /// <param name="taskElement"></param>
        void EditTask(TaskElement taskElement);
        /// <summary>
        /// Отправка занятие в архив
        /// </summary>
        /// <param name="taskElementId"></param>
        void SendTaskElementToArchive(int taskElementId);
        /// <summary>
        /// Возвращает занятие по Id
        /// </summary>
        /// <param name="taskElementId"></param>
        /// <returns></returns>
        TaskElement GetTaskElement(int taskElementId);
        /// <summary>
        /// Возвращает все занятие ребёнка
        /// </summary>
        /// <param name="childId"></param>
        /// <returns></returns>
        List<TaskElement> GetChildTaskElements(int childId);
    }
}
