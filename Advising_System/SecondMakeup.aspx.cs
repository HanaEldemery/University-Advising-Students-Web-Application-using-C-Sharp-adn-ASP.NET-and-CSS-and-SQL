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
    public partial class SecondMakeup : System.Web.UI.Page
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

                conn.Open();

                int textstudentid = (int)Session["sidret"];
                int textcourseid = Int32.Parse(TextBox2.Text);
                String semcode = (String)TextBox3.Text;

                Session["cidret"] = textcourseid;
                Session["semcoderet"] = semcode;

                if (textstudentid <= 0 || textcourseid <= 0)
                {
                    Response.Write("You must fill in the Semester box with a positive integer to register");
                }
                else if (!IsStudentIdExists(connStr, textstudentid) && !IsCourseIdExists(connStr, textcourseid))
                {
                    Response.Write($"Student with ID {textstudentid} and Course with ID {textcourseid} do not exist.");
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
                    SqlCommand cmd = new SqlCommand("SELECT dbo.FN_StudentCheckSMEligibility(@CourseID, @StudentID)", conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@CourseID", textcourseid);
                    cmd.Parameters.AddWithValue("@StudentID", textstudentid);
                    //cmd.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = textcourseid });
                    //cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = textstudentid });

                    bool result = Convert.ToBoolean(cmd.ExecuteScalar());
                    //object result = cmd.ExecuteScalar();

                    if (result)//!= null && Convert.ToBoolean(result))
                    {
                        Response.Write("The student is eligible for the Second Makeup.");
                        SqlCommand cmd2 = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = textstudentid });
                        cmd2.Parameters.Add(new SqlParameter("@courseID", SqlDbType.Int) { Value = textcourseid });
                        cmd2.Parameters.Add(new SqlParameter("@studentCurr_sem", SqlDbType.VarChar, 40) { Value = semcode });

                        //conn.Open();
                        cmd2.ExecuteNonQuery();
                        //conn.Close();
                        Response.Redirect("RedirectSecMakeup.aspx");
                    }
                    else
                    {
                        Response.Write("The student is not eligible for the Second Makeup.");
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("Not Eligible for Second Makeup");
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