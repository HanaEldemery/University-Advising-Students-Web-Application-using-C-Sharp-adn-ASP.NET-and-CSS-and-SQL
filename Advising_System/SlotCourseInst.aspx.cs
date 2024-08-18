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
    public partial class SlotCourseInst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int textcourseid = Int32.Parse(TextBox1.Text);
                int textinstructorid = Int32.Parse(TextBox2.Text);

                Session["cidret"] = textcourseid;
                Session["iidret"] = textinstructorid;

                if (textcourseid <= 0 || textinstructorid <= 0)
                {
                    Response.Write("You must fill in the Semester box with a positive integer to register");
                }
                else if (!IsCourseIdExists(connStr, textcourseid) && !IsInstructorIdExists(connStr, textinstructorid))
                {
                    Response.Write($"Course ID {textcourseid} and Instructor ID {textinstructorid} do not exist.");
                }
                else if (!IsCourseIdExists(connStr, textcourseid))
                {
                    Response.Write($"Course with ID {textcourseid} does not exist in the Course table.");
                }
                else if (!IsInstructorIdExists(connStr, textinstructorid))
                {
                    Response.Write($"Instructor with ID {textinstructorid} does not exist in the Instructor table.");
                }
                else
                {
                    Response.Redirect("RedirectSlotCourseInst.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        static bool IsInstructorIdExists(string connectionString, int instructorId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Instructor WHERE instructor_id=@InstructorId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InstructorId", instructorId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        static bool IsCourseIdExists(string connectionString, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Course WHERE course_id=@CourseId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", courseId);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}