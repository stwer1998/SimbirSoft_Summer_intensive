using System;
using System.Collections.Generic;
using System.Linq;
using Task_Manager.Models;

namespace Task_Manager
{
    public class AccountReposirory : IAccountReposirory
    {
        private MyDbContext db;
        public AccountReposirory(MyDbContext _db)
        {
            db = _db;
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool GetLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool GetUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
