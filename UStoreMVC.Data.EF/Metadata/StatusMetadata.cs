using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UStoreMVC.Data.EF//.Metadata
{
    [MetadataType(typeof(StatusMetadata))]
    public partial class Status { }
    public class StatusMetadata
    {
        public int StatusID { get; set; }

        [Required(ErrorMessage = "Status Name is Required")]
        [Display(Name = "Status Name")]
        [StringLength(30, ErrorMessage = "30 Characters Max")]
        public string StatusName { get; set; }

        [Range(1, 4, ErrorMessage = "Order Status code range is 1-4")]
        [Display(Name = "Order Status")]
        public int StatusOrder { get; set; }

        [StringLength(100, ErrorMessage = "100 Characters Max")]
        public string Notes { get; set; }
    }
}
