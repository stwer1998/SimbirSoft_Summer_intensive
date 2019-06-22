using System;

namespace Task_Manager.Models
{
    /// <summary>
    /// Класс содержащий расписание занятий
    /// </summary>
    public class TaskForDate
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int TaskForDateId { get; private set; }

        /// <summary>
        /// Занятие
        /// </summary>
        public TaskElement TaskElement { get; set; }

        /// <summary>
        /// Время когда должено выполнено занятие
        /// </summary>
        public DateTime DateOfTask { get; set; }

        /// <summary>
        /// Идентификатор ребёнка которому принадлежит запись
        /// </summary>
        public int ChildId { get; set; }

        /// <summary>
        /// статус занятие (по расписанию, пропушенное ...)
        /// </summary>
        public Status StatusTask { get; set; }

    }

    public enum Status
    {
        Schedule,
        Missed,
        Done
    }
}
