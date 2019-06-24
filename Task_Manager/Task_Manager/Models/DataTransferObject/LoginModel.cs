using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
