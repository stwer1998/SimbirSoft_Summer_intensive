using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
