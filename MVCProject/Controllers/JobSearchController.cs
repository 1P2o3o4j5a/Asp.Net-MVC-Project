using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class JobSearchController : Controller
    {
        MVCProject1Entities dbobj = new MVCProject1Entities();
        // GET: JobSearch
        public ActionResult DisplayAllJob_Pageload()
        {
            return View(GetData());
        }
        private JobSearchCls GetData()
        {
            var joblist = new JobSearchCls();
            List<string> lst = new List<string>();
            var job = dbobj.JobDetails.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.jId = e.Job_Id;
                jobcls.cId = e.C_Id;
                jobcls.jTitle = e.Job_Title;
                jobcls.jDesp = e.Job_Desp;
                jobcls.jSkills = e.Skills;
                jobcls.jExp = e.Experience;
                jobcls.jSalary = e.Salary;
                jobcls.jLoc = e.Location;
                jobcls.jLastDate = e.Laste_Date;
                jobcls.jStatus = e.Status;
                joblist.selectjob.Add(jobcls);
            }
            return joblist;
        }
        public ActionResult JobSearch_Click(JobSearchCls clsobj)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jSkills))
            {
                qry += " and Skills like '%" + clsobj.insertse.jSkills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jExp))
            {
                qry += " and Experience like '%" + clsobj.insertse.jExp + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jLoc))
            {
                qry += " and Location like '%" + clsobj.insertse.jLoc + "%'";
            }
            return View("DisplayAllJob_Pageload", getdata1(clsobj,qry));
        }
        private JobSearchCls getdata1(JobSearchCls clsobj, string qry)
        {
            using (var con=new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearches", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearchCls();
                while(dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.jId = Convert.ToInt32(dr["Job_Id"].ToString());
                    jobcls.cId = Convert.ToInt32(dr["C_Id"].ToString());
                    jobcls.jTitle = dr["Job_Title"].ToString();
                    jobcls.jDesp = dr["Job_Desp"].ToString();
                    jobcls.jSkills = dr["Skills"].ToString();
                    jobcls.jExp = dr["Experience"].ToString();
                    jobcls.jSalary = dr["Salary"].ToString();
                    jobcls.jLoc = dr["Location"].ToString();
                    jobcls.jLastDate= dr["Laste_Date"].ToString();
                    jobcls.jStatus = dr["Status"].ToString();

                    joblist.selectjob.Add(jobcls); 
                }
                con.Close();
                return joblist;
            }
        }

    }
}