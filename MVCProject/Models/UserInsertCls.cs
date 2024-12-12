using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class stclass
    {
        public int sId { set; get; }
        public string sName { set; get; }
    }
    public class Checkboxlist
    {
        public string Value { set; get; }
        public string Text { set; get; }
        public bool IsChecked { set; get; }
    }

    public class UserInsertCls
    {
        public int sId { set; get; }
        public string sName { set; get; }

        public List<Checkboxlist> MyQualification { get; set; }
        public string[] SelectedQual { set; get; }
        public int uId { set; get; }

        [Required(ErrorMessage = "Enter Name")]
        public string uName { set; get; }
        [Range(22, 45, ErrorMessage = "Enter Age")]
        public int uAge { set; get; }
        [Required(ErrorMessage = "Enter Address")]
        public string uAddress { set; get; }
        [EmailAddress(ErrorMessage = "Enter valid Email")]
        public string uEmail { set; get; }
        [Required(ErrorMessage = "Enter Phone number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string uPhone { set; get; }
        public string uGender { set; get; }
        public string uQual { set; get; }
        [Required(ErrorMessage = "Enter Skills")]
        public string uSkills { set; get; }
        [Required(ErrorMessage = "Enter Experience")]
        public string uExp { set; get; }
        [Required(ErrorMessage = "Enter Location")]
        public string uLoc { set; get; }
        public string uPhoto { set; get; }
        [Required(ErrorMessage = "Enter Username")]
        public string uUsername { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string uPassword { set; get; }
        [Compare("uPassword", ErrorMessage = "Password mismatch")]
        public string uConpassword { set; get; }
        public string usermsg { set; get; }
    }
}