using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager
{
    public class MyDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<TaskType> Types { get; set; }
        public DbSet<TaskModel> TaskModels { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
