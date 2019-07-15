using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UStoreMVC.Data.EF;

namespace uStoreMvc.Controllers
{    
    public class ProductController : Controller
    {
        uStoreEntities db = new uStoreEntities();
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }//index()
        public ActionResult Details(int id)
        {
            return View(db.Products.Find(id));
        }//Details(int id)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
            "ProductID,Name,Description,Price,UnitsInStock,ProductImage,Notes,ReferenceURL")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }//if

            return View(product);

        }//Create([Bind..... Product product)

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }//if
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }//if
            return View(product);
        }//edit(int? id)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
            "ProductID,Name,Description,Price,UnitsInStock,ProductImage,Notes,ReferenceURL")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }//if
            return View(product);
        }//Edit([Bind....Product product)

        public ActionResult Delete(int id)
        {

            //refactored code:  db.Products.Remove(db.Products.Find(id));

            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }//Delete(int id)


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); //gets rid of connection object, not db.
            }//if
            base.Dispose(disposing);
        }//dispose(bool disposing)

    }
}

