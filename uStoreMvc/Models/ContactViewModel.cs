using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace uStoreMvc.Models
{
    public class ContactViewModel
    {
        //just building a class - fields, properties, ctors, method
        //set up error messages for contact page
        //first and last name
        [Required(ErrorMessage = "* Required")]
        [StringLength(25, ErrorMessage = "*Field limitd to 25 characters")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "* Required")]
        [StringLength(25, ErrorMessage = "*Field limitd to 25 characters")]
        public string lastname { get; set; }

        //email
        [Required(ErrorMessage = "* Required")]
        [EmailAddress(ErrorMessage = "* Please enter a valid email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string email { get; set; }

        //subject
        [StringLength(100, ErrorMessage = "*Less than 100 characters")]
        public string subject { get; set; }

        //message
        [Required(ErrorMessage = "* Required")]
        [UIHint("MultiLineText")]
        public string message { get; set; }

    }//class
}//namespace