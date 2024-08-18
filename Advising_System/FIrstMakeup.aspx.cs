using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class FIrstMakeup : System.Web.UI.Page
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

                int textstudentid = (int)Session["sidret"];
                int textcourseid = Int32.Parse(TextBox2.Text);
                String currsem = TextBox3.Text;

                Session["cidret"] = textcourseid;

                if (textstudentid <= 0 || textcourseid <= 0)
                {
                    Response.Write("You must fill in the Semester box with a positive integer to register");
                }
                /*else if (!(int.TryParse(TextBox1.Text, out int value1)) || !(int.TryParse(TextBox2.Text, out int value2)))
                {
                    Response.Write("Must fill this textbox");
                }*/
                else if (string.IsNullOrEmpty(currsem))
                {
                    Response.Write("You must fill this textbox");
                }
                else if (!IsCourseIdExists(connStr, textcourseid) && !IsStudentIdExists(connStr, textstudentid))
                {
                    Response.Write($"Course ID {textcourseid} and Student ID {textstudentid} do not exist.");
                }
                else if (!IsStudentIdExists(connStr, textstudentid))
                {
                    Response.Write($"Student with ID {textstudentid} does not exist in the Student table.");
                }
                else if (!IsCourseIdExists(connStr, textcourseid))
                {
                    Response.Write($"Course with ID {textcourseid} does not exist in the Course table.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = textstudentid });
                    cmd.Parameters.Add(new SqlParameter("@courseID", SqlDbType.Int) { Value = textcourseid });
                    cmd.Parameters.Add(new SqlParameter("@studentCurr_sem", SqlDbType.VarChar, 40) { Value = currsem });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("RedirectFirstMakeup.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Not Eligible for First Makeup");
            }
        }
        static bool IsStudentIdExists(string connectionString, int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Student WHERE student_id=@StudentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

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