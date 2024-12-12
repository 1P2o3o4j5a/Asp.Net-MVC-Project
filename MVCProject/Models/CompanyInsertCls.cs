using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class CompanyInsertCls
    {
        public int cId { set; get; }
        [Required(ErrorMessage = "Enter Company Name")]
        public string cName { set; get; }
        [Required(ErrorMessage = "Enter Address")]
        public string cAddress { set; get; }
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string cEmail { set; get; }
        [Required(ErrorMessage = "Enter website")]
        public string cWebsite { set; get; }

        [Required(ErrorMessage = "Enter Phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string cPhone { set; get; }
        [Required(ErrorMessage = "Enter Username")]
        public string cUsername { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string cPassword { set; get; }
        [Compare("cPassword", ErrorMessage = "Password mismatch")]
        public string cConpassword { set; get; }
        public string companymsg { set; get; }
    }
}