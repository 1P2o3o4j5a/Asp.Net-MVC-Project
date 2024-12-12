using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ApplyController : Controller
    {
        MVCProject1Entities dbobj = new MVCProject1Entities();
        // GET: Apply
        public ActionResult Apply_Pageload(int cid,int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }
        public ActionResult Apply_Click(ApplyCls clsobj, JobSearchCls obj,HttpPostedFileBase file)
        {
            if(ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photo");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\Photo", fname);
                    clsobj.CV = fullpath;//set
                }
                dbobj.sp_cvInsert(Convert.ToInt32(Session["uid"]), Convert.ToInt32(TempData["jid"]), clsobj.CV, DateTime.Now.ToString("yyyy-MM-dd"), "Applied");
                clsobj.Msg = "Application Submitted";
                return View("Apply_Pageload", clsobj);
            }
            return View("Apply_Pageload", clsobj);
        }
    }
}