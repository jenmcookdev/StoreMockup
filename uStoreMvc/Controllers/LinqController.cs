
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UStoreMVC.Data.Linq;

namespace uStoreMvc.Controllers
{
    public class LinqController : Controller
    {
        LinqDAL linq = new LinqDAL();

        // GET: Linq
        public ActionResult Index()
        {
            return View(linq.GetProducts());
        }//index()

        public ActionResult DisplayProducts()
        {
            return View(linq.GetProducts());
        }//DisplayProducts()

    }//class
}//namespace