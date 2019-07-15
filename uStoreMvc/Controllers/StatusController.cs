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
{//Created automatically MVC 5 Controller with views, using Entity Framework
    public class StatusController : Controller
    {
        //private uStoreEntities db = new uStoreEntities();
        StatusRepository repo = new StatusRepository();

        // GET: Status
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Index()
        {
            //return View(db.Statuses.ToList());
            return View(repo.Get());
        }

        // GET: Status/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Status status = db.Statuses.Find(id);
            Status status = repo.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: Status/Create
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,StatusName,StatusOrder,Notes")] Status status)
        {
            if (ModelState.IsValid)
            {
                //db.Statuses.Add(status);
                //db.SaveChanges();
                repo.Add(status);
                return RedirectToAction("Index");
            }

            return View(status);
        }

        // GET: Status/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Status status = db.Statuses.Find(id);
            Status status = repo.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,StatusName,StatusOrder,Notes")] Status status)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(status).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(status);
                return RedirectToAction("Index");
            }
            return View(status);
        }

        // GET: Status/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Status status = db.Statuses.Find(id);
            Status status = repo.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Status status = db.Statuses.Find(id);
            //db.Statuses.Remove(status);
            //db.SaveChanges();
            Status status = repo.Find(id);
            repo.Remove(status);
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
