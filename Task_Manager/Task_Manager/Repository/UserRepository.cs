using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class UserRepository : IUserRepository
    {
        private MyDbContext db;
        public UserRepository(MyDbContext db)
        {
            this.db = db;
        }

        public void EditUser(User newUser)
        {
            var user = db.Users.FirstOrDefault(x=>x.UserId==newUser.UserId);
            user.Name = newUser.Name;
            user.Surname = newUser.Surname;
            user.Login = newUser.Login;
            user.Password = newUser.Password;
            db.SaveChanges();
        }

        public User GetUser(string login)
        {
            return db.Users.FirstOrDefault(x=>x.Login==login);
        }

        public int GetUserId(string login)
        {
            return db.Users.FirstOrDefault(x => x.Login == login).UserId;
        }

        public void UpdateUserUpdateTime(string login)
        {
            var user = db.Users.FirstOrDefault(x => x.Login == login);
            user.UpdateTime = DateTime.Now.Date;
            db.SaveChanges();
        }
    }
}
