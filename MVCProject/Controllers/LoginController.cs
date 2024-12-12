using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class LoginController : Controller
    {
        MVCProject1Entities dbobj = new MVCProject1Entities();
        // GET: Login
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult Login_Click(LoginCls clsobj)
        {
           if(ModelState.IsValid)
            {
                var getcid = dbobj.sp_countLoginId(clsobj.Username, clsobj.Password).FirstOrDefault();
                int cid = Convert.ToInt32(getcid);
                if (cid == 1)
                {
                    var getregid = dbobj.sp_regId(clsobj.Username, clsobj.Password).FirstOrDefault();
                    Session["uid"] = getregid;
                    var getlogtype = dbobj.sp_loginType(clsobj.Username, clsobj.Password).FirstOrDefault();
                    string logtype = getlogtype.ToString();
                    if (logtype == "Admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                    else if (logtype == "User")
                    {
                        return RedirectToAction("UserHome");
                    }
                }
                else
                {
                    ModelState.Clear();
                    clsobj.LoginMsg = "Invalid Username or Password";
                    return View("Login_Pageload", clsobj);
                }               
            }
            return View("Login_Pageload", clsobj);
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
    }
}