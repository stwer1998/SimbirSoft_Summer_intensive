using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Interfaces;
using Task_Manager.Models;

namespace Task_Manager.Repository
{
    public class ChildRepository : IChildRepository
    {
        private MyDbContext db;
        public ChildRepository(MyDbContext db)
        {
            this.db = db;
        }

        public void AddChild(Child child)
        {
            db.Childs.Add(child);
            db.SaveChanges();
        }

        public void DeleteChild(int idChild)
        {
            db.Childs.Remove(db.Childs.First(x=>x.ChildId==idChild));
            db.SaveChanges();
        }

        public void EditChild(Child newChild)
        {
            var child = db.Childs.FirstOrDefault(x=>x.ChildId==newChild.ChildId);
            child.Name = newChild.Name;
            child.Surname = newChild.Name;
            db.SaveChanges();
        }

        public Child GetChild(int childId)
        {
            return db.Childs.FirstOrDefault(x=>x.ChildId==childId);
        }

        public List<Child> GetUserChilds(int idUser)
        {
            return db.Childs.Where(x => x.UserId == idUser).ToList();
        }
    }
}
