using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Manager.Interfaces
{
    public interface IUser
    {
        string Login { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Password { get; set; }
        ICollection<IChild> Childs { get; set; }
    }
}
