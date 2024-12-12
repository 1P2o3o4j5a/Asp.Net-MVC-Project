using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "Enter Username")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Enter Password")]
        public string Password { set; get; }
        public string LoginMsg { set; get; }
    }
}