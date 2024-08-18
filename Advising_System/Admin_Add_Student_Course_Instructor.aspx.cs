using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Admin_Add_Student_Course_Instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
        protected void addStudentCourseInstructor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    int studentIDInput = Convert.ToInt32(student.Text);
                    int courseIDInput = Convert.ToInt32(course.Text);
                    int instructorIDInput = Convert.ToInt32(instructor.Text);
                    int semesterIDInput = Convert.ToInt32(semester.Text);

                    SqlCommand courseDeleteproc = new SqlCommand("Procedures_AdminLinkStudent", conn);
                    courseDeleteproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseDeleteproc.Parameters.Add(new SqlParameter("@studentID", studentIDInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@cours_id", courseIDInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@instructor_id", instructorIDInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@semester_code", semesterIDInput));

                    courseDeleteproc.ExecuteNonQuery();

                    Response.Write("Linked Student With ID: " + studentIDInput + " With Course With ID: " + courseIDInput + " With Instructor With ID: " + instructorIDInput);

                    conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        protected void backHomeFn(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomePage.aspx");
        }
    }
}