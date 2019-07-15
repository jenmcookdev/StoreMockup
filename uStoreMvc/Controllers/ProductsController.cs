using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UStoreMVC.Data.EF;
using uStoreMVC.Domain.Repositories;


namespace uStoreMvc.Controllers
{ //Created automatically MVC 5 Controller with views, using Entity Framework
    public class ProductsController : Controller
    {
        private uStoreEntities db = new uStoreEntities();//For ViewBag lines.
        ProductRepository repo = new ProductRepository();

        // GET: Products
        public ActionResult Index()
        {
            //var products = db.Products.Include(p => p.Category).Include(p => p.Status);
            //return View(products.ToList());
            return View(repo.Get());
        }

        // GET: Products/Details/5
        //[Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        // GET: Products/Create
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Description,Price,UnitsInStock,ProductImage,StatusID,CategoryID,Notes,ReferenceURL")]
        Product product, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                #region Simple File Upload
                string image = "noImage.png";

                if (ProductImage != null)
                {
                    image = ProductImage.FileName;

                    string picExt = image.Substring(image.LastIndexOf("."));

                    string[] goodPicExts = new string[] { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodPicExts.Contains(picExt.ToLower()))
                    {
                        image = Guid.NewGuid() + picExt;

                        ProductImage.SaveAs(Server.MapPath("~/Content/images/product/" + image));
                    }
                    else
                    {
                        image = "noImage.png";
                    }
                    product.ProductImage = image;
                }
                #endregion

                //db.Products.Add(product);
                //db.SaveChanges();
                repo.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusID);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,Price,UnitsInStock,ProductImage,StatusID,CategoryID,Notes,ReferenceURL")]
        Product product, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                #region Simple File Upload
                if(ProductImage != null)
                {
                    string image = ProductImage.FileName;

                    string picExt = image.Substring(image.LastIndexOf("."));

                    string[] goodPicExts = new string[] { ".jpg", ".jpeg", ".png", ".gif" };

                    if (goodPicExts.Contains(picExt.ToLower()))
                    {
                        image = Guid.NewGuid() + picExt;

                        ProductImage.SaveAs(Server.MapPath("~/Content/images/product/" + image));
                    }
                    product.ProductImage = image;

                    if (Session["currentImage"].ToString() != "noImage.png")
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/images/product/" +
                            Session["currentImage"].ToString()));

                        //for thumbnail images:
                        //System.IO.File.Delete(Server.MapPath("~/Content/images/t_product/" +
                        //Session["currentImage"].ToString()));

                    }
                }
                #endregion

                //db.Entry(product).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.StatusID = new SelectList(db.Statuses, "StatusID", "StatusName", product.StatusID);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Product product = db.Products.Find(id);
            Product product = repo.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = db.Products.Find(id);
            //db.Products.Remove(product);
            //db.SaveChanges();
            Product product = repo.Find(id);
            repo.Remove(product);
            //if (product.ProductImage != "noImage.png")
            //{
            //        System.IO.File.Delete(Server.MapPath("~/Content/images/product/" +
            //            product.ProductImage));

            //        //for thumbnail images:
            //        //System.IO.File.Delete(Server.MapPath("~/Content/images/t_product/" +
            //        //product.ProductImage));
            //}
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
