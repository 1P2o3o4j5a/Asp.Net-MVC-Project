using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class CompanyRegController : Controller
    {
        MVCProject1Entities dbobj = new MVCProject1Entities();
        // GET: CompanyReg
        public ActionResult CompanyInsert_Pageload()
        {
            return View();
        }
        public ActionResult ComapnyInsert_Click(CompanyInsertCls clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxRegId().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_companyReg(regid, clsobj.cName, clsobj.cAddress,clsobj.cEmail,clsobj.cWebsite, clsobj.cPhone);
                dbobj.sp_loginInsert(regid, clsobj.cUsername, clsobj.cConpassword, "Admin");
                clsobj.companymsg = "Successfully inserted";
                return View("CompanyInsert_Pageload", clsobj);
            }
            return View("CompanyInsert_Pageload", clsobj);
        }
    }
}