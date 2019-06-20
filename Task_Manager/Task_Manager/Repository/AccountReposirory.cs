﻿using System;
using System.Collections.Generic;
using System.Linq;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
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

        User IAccountReposirory.GetUser(string login, string password)
        {
            var u=db.Users.FirstOrDefault(x=>x.Login==login&&x.Password==password);
            if (u.Login == login) { return u; }
            else return null;
        }
    }
}
