using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class TaskModel
    {
        public int ChildId { get; set; }
        [Required(ErrorMessage = "Не указано категория занятие")]
        public string TypeTask { get; set; }
        [Required(ErrorMessage = "Не указано название занятие")]
        public string NameTask { get; set; }
        [Required(ErrorMessage = "Не указано периодичность")]
        [Range(1,int.MaxValue,ErrorMessage ="Пероидичнось должно быть в интервале от 1 до 500")]
        public int Periodicity { get; set; }
        [Required(ErrorMessage = "Не указано дата начало")]
        public DateTime StartDate { get; set; }

    }
}
