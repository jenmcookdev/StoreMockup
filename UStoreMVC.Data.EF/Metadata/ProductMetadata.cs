using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UStoreMVC.Data.EF//.Metadata
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product { }
    public class ProductMetadata
    {   
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        [StringLength(150, ErrorMessage = "150 Characters Max")]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        [UIHint("MultiLineText")]
        [DisplayFormat(NullDisplayText ="[-N/A-]")]
        public string Description { get; set; }

        [Range(0.01, 1000.00, ErrorMessage = "Price must be between $0.01 to $1000.00")]
        [DisplayFormat(DataFormatString ="{0:c}", NullDisplayText = "[-N/A-]")]
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
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string Notes { get; set; }

        [StringLength(1024, ErrorMessage = "1024 Characters Max")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        public string ReferenceURL { get; set; }
    }
}
