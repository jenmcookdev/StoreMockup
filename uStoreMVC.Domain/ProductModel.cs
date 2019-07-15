using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace uStoreMVC.Domain
{
    public class ProductModel
    {   //Never allow users to edit Primary or FGN Keys
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        [StringLength(150, ErrorMessage = "150 Characters Max")]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Units Required! If None Enter Zero")]
        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }

        [Display(Name = "Product Image")]
        [StringLength(75, ErrorMessage = "75 Characters Max")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Required.")]
        public int StatusID { get; set; }

        public int CategoryID { get; set; }

        [StringLength(500, ErrorMessage = "Please keep notes under 500 characters")]
        public string Notes { get; set; }

        [StringLength(1024, ErrorMessage = "1024 Characters Max")]
        public string ReferenceURL { get; set; }

    }//class
}//namespace
