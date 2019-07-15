using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStoreMVC.Data.EF;

namespace uStoreMVC.Domain.Repositories
{
    public class CategoryRepository
    {
        private uStoreEntities db = new uStoreEntities();

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }//Get()

        public Category Find(int? id)
        {
            return db.Categories.Find(id);
        }//Find(int? id)

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }//Add(Category category)

        public void Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }//Add(Category category)

        public void Remove(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }//Remove(Category category)

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
