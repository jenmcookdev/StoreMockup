using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uStoreMVC.Domain
{
    public class ProductStatusViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; } 
        public int UnitsInStock  { get; set; }
        public string StatusName { get; set; }

    }//class
}//namespace
