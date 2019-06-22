using System;

namespace Task_Manager.Models
{
    public class TaskElement
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int TaskElementId { get; set; }

        /// <summary>
        /// Категория занятии
        /// </summary>
        public string TaskCategory { get; set; }

        /// <summary>
        /// наименование занятии
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Периодичность занятии
        /// </summary>
        public int Periodicity { get; set; }

        /// <summary>
        /// Идентификатор владельца
        /// </summary>
        public int ChildId { get; set; }

        /// <summary>
        /// Дато добавление
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата покзывающее что запись не в архиве
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Дата подсчета
        /// </summary>
        public DateTime Point { get; set; }
    }
}
