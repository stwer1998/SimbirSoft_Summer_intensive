using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Не указано категория занятие")]
        public string TaskCategory { get; set; }

        /// <summary>
        /// наименование занятии
        /// </summary>
        [Required(ErrorMessage = "Не указано название занятие")]
        public string TaskName { get; set; }

        /// <summary>
        /// Периодичность занятии
        /// </summary>
        [Required(ErrorMessage = "Не указано периодичность")]
        [Range(1, int.MaxValue, ErrorMessage = "Пероидичнось должно быть в интервале от 1 до 500")]
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
