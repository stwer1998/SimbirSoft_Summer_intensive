using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Interfaces;

namespace Task_Manager
{
    public class User : IUser
    {
        public int UserId { get;private set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public ICollection<IChild> Childs { get; set; }
        public string Login { get; set; }
    }
}
