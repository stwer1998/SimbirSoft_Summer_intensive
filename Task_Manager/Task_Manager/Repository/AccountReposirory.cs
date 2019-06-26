using System;
using System.Collections.Generic;
using System.Linq;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class AccountReposirory : IAccountReposirory
    {
        private MyDbContext db;
        public AccountReposirory(MyDbContext db)
        {
            this.db = db;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public bool CheckLogin(string login)
        {
            var user = db.Users.FirstOrDefault(x => x.Login == login);
            if (user == null || user.Login != login) { return false; }
            else return true;
        }

        public User GetUser(string login, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null || user.Login!=login ) { return null; }
            else return user;
        }
    }
}
