using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; private set; }
       
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Пароль для входа
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }
        
        /// <summary>
        /// Логин для входа
        /// </summary>
        public string Login { get; set; }
    }
}
