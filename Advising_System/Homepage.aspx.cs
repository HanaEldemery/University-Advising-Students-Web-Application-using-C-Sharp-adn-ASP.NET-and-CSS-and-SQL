using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void viewAdvStudents(object sender, EventArgs e)
        {

            Response.Write("Please wait...");
            Response.Redirect("YourStudents.aspx");

        }

        protected void insert(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("GradPlan.aspx");
        }

        protected void insert1(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("InsertCourse.aspx");
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("UpdateGradDate.aspx");
        }

        protected void toDelete_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("DeleteCourse.aspx");
        }

        protected void view_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("ViewStudents.aspx");
        }

        protected void view1_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("ViewPendingReq.aspx");
        }

        protected void appRej_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("CourseApproval.aspx");
        }

        protected void aprj_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("HoursApproval.aspx");
        }

        protected void show_Click(object sender, EventArgs e)
        {
            Response.Write("Please wait...");
            Response.Redirect("AllReq.aspx");
        }
    }
}