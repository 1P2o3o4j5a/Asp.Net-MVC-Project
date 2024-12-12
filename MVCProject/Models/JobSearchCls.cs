using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class JobSearchCls
    {
        public JobSearchCls() 
        {
            selectjob = new List<jsearch>();
            insertse=new jsearch();
        }
        public jsearch insertse { get; set; }
        public List<jsearch> selectjob { get; set; }
    }
    public class  jsearch
    {
        public int jId { get; set; }
        public int cId { get; set; }
        public string jTitle { get; set; }
        public string jDesp { get; set; }
        public string jSkills { get; set; }
        public string jExp { get; set; }
        public string jSalary { get; set; }
        public string jLoc { get; set; }
        public string jStatus { get; set; }
        public string jLastDate { get; set; }
    }
}