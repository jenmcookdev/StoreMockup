using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UStoreMVC.Data.EF;

namespace uStoreMVC.Domain.Repositories
{
    public class ProductRepository
    {
        private uStoreEntities db = new uStoreEntities();

        public List<Product> Get()
        {
            return db.Products.ToList();
        }//Get()

        public Product Find(int? id)
        {
            return db.Products.Find(id);
        }//Find(int? id)

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }//Add(Product product)

        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }//Add(Product product)

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }//Remove(Product product)

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
