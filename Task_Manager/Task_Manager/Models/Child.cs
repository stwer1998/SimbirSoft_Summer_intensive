using System;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class Child 
    {
        /// <summary>
        /// Идентификатор ребенка
        /// </summary>
        public int ChildId { get; private set; }

        /// <summary>
        /// Имя ребёнка
        /// </summary>
        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get;  set; }

        /// <summary>
        /// Фамилия ребёнка
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Идентификатор пользователя которому принадлежит ребёнок
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Дата добавления ребёнка
        /// </summary>
        public DateTime RegisterDate { get; set; }//Это поля испотьзуется когда запрашивается история ребёнка

        /// <summary>
        /// Врямя последней пересчитывание расписание
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
