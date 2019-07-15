using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uStoreMVC.Data.ADO;
using uStoreMVC.Domain;

namespace uStoreMvc.Controllers
{
    public class ProductsADOController : Controller
    {
        ProductsDAL products = new ProductsDAL();
        // GET: ProductsADO
        public ActionResult Index()
        {
            ViewBag.productNames = products.GetProductNames();
            return View();
        }//Index()

        public ActionResult DisplayProducts()
        {
            return View(products.GetProducts());
        }//DisplayProducts

        public ActionResult CreateProducts()
        {
            return View();
        }//CreateProduct()

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProducts(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                products.CreateProducts(product);
                return RedirectToAction("DisplayProducts");
            }//if
            return View(products);
        }//CreateProducts(ProductModel product)

        public ActionResult DeleteProduct(int id)
        {
            products.DeleteProduct(id);
            return RedirectToAction("DisplayProducts");
        }//DeleteProducts(int id)

        public ActionResult UpdateProduct(int id)
        {
            return View(products.GetThatProduct(id));
        }//UpdateProduct(int id)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                products.UpdateProduct(product);
                return RedirectToAction("DisplayProducts");
            }//if
            return View(product);
        }//UpdateProduct(ProductModel product)

    }//class
}//namespace