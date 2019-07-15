using System.Collections.Generic;
using System.Linq;
using uStoreMVC.Domain;

namespace UStoreMVC.Data.Linq
{
    public class LinqDAL
    {
        LinqDALDataContext db = new LinqDALDataContext();

        public List<ProductStatusViewModel> GetInStock()
        {
            var StatusID = from p in db.LinqProducts
                           join s in db.LinqStatuses on p.StatusID equals s.StatusID
                           where p.StatusID == 1
                           orderby p.Name
                           select new
                           {
                               p.ProductID,
                               p.Name,
                               p.Description,
                               p.Price,
                               p.UnitsInStock,
                               s.StatusName
                           };
            var StatusIDList = new List<ProductStatusViewModel>();

            foreach (var item in StatusID)
            {
                StatusIDList.Add(
                    new ProductStatusViewModel()
                    {
                        ProductID = item.ProductID,
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                        UnitsInStock = item.UnitsInStock,
                        StatusName = item.StatusName
                    });

            }//foreach
            return StatusIDList; 

        }//GetStatusID()

    public List<LinqProduct> GetProducts()
        {
            List<LinqProduct> products = db.LinqProducts.OrderBy(p => p.Price).ToList();
            return products;

        }//GetProducts()
    }//class
}//namespace
