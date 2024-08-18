using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Welcome Student " + (int)Session["sidret"]+"!");
        }

        protected void telephone(object sender, EventArgs e)
        {
            Response.Redirect("Student Telephone.aspx");
        }

        protected void sendCrsReq(object sender, EventArgs e)
        {
            Response.Redirect("Send Crs Req.aspx");
        }

        protected void sendCrHrsReq(object sender, EventArgs e)
        {
            Response.Redirect("Send Cr Hrs Req.aspx");
        }

        protected void optional(object sender, EventArgs e)
        {
            Response.Redirect("View Optional.aspx");
        }

        protected void required(object sender, EventArgs e)
        {
            Response.Redirect("View Required.aspx");
        }

        protected void missing(object sender, EventArgs e)
        {
            Response.Redirect("View Missing.aspx");
        }

        protected void available(object sender, EventArgs e)
        {
            Response.Redirect("View Available.aspx");
        }

        protected void gradPlan(object sender, EventArgs e)
        {
            Response.Redirect("RedirectGradPlan.aspx");
        }

        protected void inst(object sender, EventArgs e)
        {
            Response.Redirect("NotPaidInst.aspx");
        }

        protected void all(object sender, EventArgs e)
        {
            Response.Redirect("CoursesC.aspx");
        }

        protected void first(object sender, EventArgs e)
        {
            Response.Redirect("FIrstMakeup.aspx");
        }

        protected void second(object sender, EventArgs e)
        {
            Response.Redirect("SecondMakeup.aspx");
        }

        protected void crslin(object sender, EventArgs e)
        {
            Response.Redirect("CoursesSlotsIns.aspx");
        }

        protected void slcrsin(object sender, EventArgs e)
        {
            Response.Redirect("SlotCourseInst.aspx");
        }

        protected void choose(object sender, EventArgs e)
        {
            Response.Redirect("InstructorChoose.aspx");
        }

        protected void deets(object sender, EventArgs e)
        {
            Response.Redirect("ViewCoursePrereqDedirect.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["sidret"] = null;
            Response.Redirect("Student Register Login.aspx");
        }
    }
}