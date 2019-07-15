using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UStoreMVC.Data.EF//.Metadata
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category { }
    public class CategoryMetadata
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name is Required")]
        [Display(Name = "Category Name")]
        [StringLength(100, ErrorMessage = "100 Characters Max")]
        public string CategoryName { get; set; }

        [StringLength(500, ErrorMessage = "500 Characters Max")]
        public string Notes { get; set; }
    }
}

