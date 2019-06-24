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

        public void DeleteChild(int userId,int idChild)
        {
            db.Childs.Remove(db.Childs.First(x=>x.ChildId==idChild));
            db.SaveChanges();
        }

        public void EditChild(int childId,Child newChild)
        {
            var child = db.Childs.FirstOrDefault(x=>x.ChildId== childId);
            child.Name = newChild.Name;
            child.Surname = newChild.Surname;
            db.SaveChanges();
        }

        public Child GetChild(int childId)
        {
            return db.Childs.FirstOrDefault(x=>x.ChildId==childId);
        }

        public bool GetNameSurnameChild(int userId, Child child)
        {
            var ch = db.Childs.FirstOrDefault(x=>x.UserId==userId
            &&x.Name==child.Name
            &&x.Surname==child.Surname);
            if (ch != null && ch.UserId == userId && ch.Name == child.Name && ch.Surname == child.Surname)
            {
                return false;
            }
            else return true;
        }

        public List<Child> GetUserChilds(int idUser)
        {
            var result= db.Childs.Where(x => x.UserId == idUser).ToList();
            if (result == null) { return new List<Child>(); }
            else return result;
        }
    }
}
