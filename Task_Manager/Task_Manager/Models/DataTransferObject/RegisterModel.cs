using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
