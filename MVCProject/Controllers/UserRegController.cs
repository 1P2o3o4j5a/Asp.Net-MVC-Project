using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class UserRegController : Controller
    {
        MVCProject1Entities dbobj = new MVCProject1Entities();
        // GET: UserReg
        public ActionResult UserInsert_Pageload()
        {
            //dropdown
            List<stclass> stList = new List<stclass>
            {
                new stclass { sId = 1, sName = "Kerala" },
                new stclass { sId = 2, sName = "Karnataka" },
                new stclass { sId = 3, sName = "Assam" },
                new stclass { sId = 4, sName = "Tamil nadu" }
            };
            ViewBag.Selstates = new SelectList(stList, "sId", "sName");

            // chechbox
            UserInsertCls user = new UserInsertCls();
            user.MyQualification = getQualificationData();
            return View(user);
        }
        public List<Checkboxlist> getQualificationData()
        {
            List<Checkboxlist> sts = new List<Checkboxlist>()
            {
                new Checkboxlist {Value="SSLC",Text="SSLC",IsChecked=true},
                 new Checkboxlist {Value="Plus Two",Text="Plus Two",IsChecked=false},
                  new Checkboxlist {Value="Btech",Text="Btech",IsChecked=false},
                   new Checkboxlist {Value="Mtech",Text="Mtech",IsChecked=false}
            };
            return sts;
        }
        public ActionResult UserInsert_click(UserInsertCls clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photo");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\Photo", fname);
                    clsobj.uPhoto = fullpath;//set
                }
                List<stclass> stList = new List<stclass>
                 {
                new stclass { sId = 1, sName = "Kerala" },
                new stclass { sId = 2, sName = "Karnataka" },
                new stclass { sId = 3, sName = "Assam" },
                new stclass { sId = 4, sName = "Tamil nadu" }
                 };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                int selectedId = Convert.ToInt32(form["ddlstates"]);
                stclass selectedItem = stList.FirstOrDefault(c => c.sId == selectedId);
                clsobj.sId = selectedItem.sId;
                clsobj.sName = selectedItem.sName;

                var quid = string.Join(",", clsobj.SelectedQual);
                clsobj.uQual = quid;
                clsobj.MyQualification = getQualificationData();

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

                dbobj.sp_userReg(regid, clsobj.uName, clsobj.uAge, clsobj.uAddress, clsobj.uEmail, clsobj.uPhone,clsobj.uGender,clsobj.sName,clsobj.uQual,clsobj.uSkills,clsobj.uExp,clsobj.uLoc,clsobj.uPhoto);
                dbobj.sp_loginInsert(regid, clsobj.uUsername, clsobj.uPassword, "User");
                clsobj.usermsg = "Successfully Inserted";
                return View("UserInsert_Pageload", clsobj);
               
            }
            else
            {
                List<stclass> stList = new List<stclass>
                 {
                new stclass { sId = 1, sName = "Kerala" },
                new stclass { sId = 2, sName = "Karnataka" },
                new stclass { sId = 3, sName = "Assam" },
                new stclass { sId = 4, sName = "Tamil nadu" }
                 };
                ViewBag.Selstates = new SelectList(stList, "sId", "sName");

                clsobj.MyQualification = getQualificationData();

                return View("UserInsert_pageload", clsobj);
            }
        }


    }
}