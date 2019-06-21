using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class Child 
    {
        public int ChildId { get; private set; }
        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get;  set; }
        public string Surname { get; set; }
        public int UserId { get; set; }
    }
}
