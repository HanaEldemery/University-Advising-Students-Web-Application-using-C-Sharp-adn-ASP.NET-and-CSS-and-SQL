using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void login(object sender, EventArgs e)
        {

        }

        protected void courseFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Delete_Course.aspx");
        }

        protected void slotFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Delete_Slot.aspx");
        }

        protected void makeupFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Add_MakeUp.aspx");
        }

        protected void paymentsFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Payments.aspx");
        }

        protected void installmentFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Issues_Installments.aspx");
        }

        protected void studentStatusFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Update_Student_Status.aspx");
        }

        protected void studentsDetailsFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Student_Details.aspx");
        }

        protected void gplansFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Graduation_Plans.aspx");
        }

        protected void transcriptFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Students_Transripts.aspx");
        }

        protected void semestersFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Semesters.aspx");
        }

        protected void advisorsFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Advisors.aspx");
        }

        protected void studentAdvisorsFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Student_Advisors.aspx");
        }

        protected void pendingRequestsFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Pending_Requests.aspx");
        }

        protected void addSemesterFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Add_Semester.aspx");
        }

        protected void addCourseFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Add_Course.aspx");
        }

        protected void addInstructorLinkCourseFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Add_Instructor_Course_Slot.aspx");
        }

        protected void addStudentLinkAdvisorFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Add_Student_Advisor.aspx");
        }

        protected void addStudentLinkCourseInstructorFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Add_Student_Course_Instructor.aspx");
        }

        protected void viewInstructorsFn(object sender, EventArgs e)
        {
            Response.Redirect("Admin_View_Instructors.aspx");
        }
    }
}