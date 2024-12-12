using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class JobDetailsController : Controller
    {
        MVCProject1Entities dbobj = new MVCProject1Entities();
        // GET: JobDetails
        public ActionResult JobInsert_Pageload()
        {
            return View();
        }
        public ActionResult JobInsert_Click(JobInsertCls clsobj)
        {
            if(ModelState.IsValid)
            {
                int userId = Convert.ToInt32(Session["uid"]);
                dbobj.sp_insertJobDetails(userId, clsobj.jobTitle, clsobj.jobDesp, clsobj.jobSkills, clsobj.jobExp, clsobj.jobSalary, clsobj.jobLoc, clsobj.jobLastDate, clsobj.jobStatus);
                clsobj.jobMsg = "Successfully inserted";
                return View("JobInsert_Pageload", clsobj);
            }
            return View("JobInsert_Pageload", clsobj);
        }
    }
}