using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Models
{
    public class User
    {
        public int UserId { get;private set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public List<Child> Childs { get; set; }
        public string Login { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
