using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано логин")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указано пароль")]
        public string Password { get; set; }
    }
}
