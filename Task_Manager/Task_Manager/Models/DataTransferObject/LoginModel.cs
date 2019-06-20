using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указано пароль")]
        public string Password { get; set; }
    }
}
