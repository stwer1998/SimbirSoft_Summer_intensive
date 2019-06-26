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
        List<TaskForDate> GetTodayTaskForUser(int childId);
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
        /// <summary>
        /// Изменяет статус запланированного задание на сделано 
        /// </summary>
        /// <param name="taskForDateId"></param>
        void SentToDone(int taskForDateId);
        /// <summary>
        /// Изменяет статус запланированного задание на пропущенно
        /// </summary>
        /// <param name="taskForDateId"></param>
        void SentToMissed(int taskForDateId);
        /// <summary>
        /// Добавляет на расписание задание как дополнительно
        /// </summary>
        /// <param name="childId"></param>
        /// <param name="taskId"></param>
        void UnScheduleTask(int childId, int taskId);
    }
}
