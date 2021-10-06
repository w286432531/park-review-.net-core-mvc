using ReviewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Repositories
{
    public class ParkRepository
    {
        public ParkContext db;

        public ParkRepository(ParkContext db)
        {
            this.db = db;
        }

        //Create
        public void Create(Park obj)
        {
            db.Parks.Add(obj);
            db.SaveChanges();
        }
        //Read
        public IEnumerable<Park> GetAll()
        {
            return db.Parks.ToList();
        }

        public Park GetByID(int id)
        {
            return db.Parks.Find(id);
        }
        // Update
        public void Update(Park obj)
        {
            db.Parks.Update(obj);
            db.SaveChanges();
        }
        // Delete
        public void Delete(Park obj)
        {
            db.Parks.Remove(obj);
            db.SaveChanges();
        }
    }
}
