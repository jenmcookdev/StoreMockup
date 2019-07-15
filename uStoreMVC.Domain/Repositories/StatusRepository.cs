using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStoreMVC.Data.EF;

namespace uStoreMVC.Domain.Repositories
{
    public class StatusRepository
    {
        private uStoreEntities db = new uStoreEntities();

        public List<Status> Get()
        {
            return db.Statuses.ToList();
        }//Get()

        public Status Find(int? id)
        {
            return db.Statuses.Find(id);
        }//Find(int? id)

        public void Update(Status status)
        {
            db.Entry(status).State = EntityState.Modified;
            db.SaveChanges();
        }//Add(Status status)

        public void Add(Status status)
        {
            db.Statuses.Add(status);
            db.SaveChanges();
        }//Add(Status status)

        public void Remove(Status status)
        {
            db.Statuses.Remove(status);
            db.SaveChanges();
        }//Remove(Status status)

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }//if
            }//if
            this.disposed = true;
        }//Dispose(bool disposing)

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }//Dispose()

    }
}
