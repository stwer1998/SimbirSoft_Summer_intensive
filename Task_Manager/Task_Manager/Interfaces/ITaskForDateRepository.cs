using System.Collections.Generic;
using Task_Manager.Models;

namespace Task_Manager.Interfaces
{
    public interface ITaskForDateRepository
    {
        /// <summary>
        /// Вернёт все занятие ребёнка на сегодня которые ещё не закончены
        /// </summary>
        /// <param name="childId"></param>
        /// <returns></returns>
        List<TaskElement> GetTodayTaskForUser(int childId);
        /// <summary>
        /// пересчитывание расписание
        /// </summary>
        /// <param name="childId"></param>
        void UpdeteScheduleChild(int childId);
        /// <summary>
        /// отметить задание которые сделяны сегодня
        /// </summary>
        /// <param name="childId"></param>
        /// <param name="idtaskarray"></param>
        void MarkDoneTasksChild(int childId, int[] idtaskarray);
    }
}
