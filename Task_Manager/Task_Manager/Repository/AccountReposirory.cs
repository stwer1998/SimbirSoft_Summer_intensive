using System;
using System.Collections.Generic;
using System.Linq;

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
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool GetLogin(string login)
        {
            var u = db.Users.FirstOrDefault(x=>x.Login==login);
            if (u == null || u.Login != login) { return false; }
            else return true;
        }

        public bool GetUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
