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
    public partial class InstructorChoose : System.Web.UI.Page
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
                int textinstructorid = Int32.Parse(TextBox2.Text);
                int textcourseid = Int32.Parse(TextBox3.Text);
                String currsem = TextBox4.Text;

                Session["iidret"] = textinstructorid;
                Session["cidret"] = textcourseid;
                Session["csemcode"] = currsem;


                if (textcourseid <= 0 || textinstructorid <= 0 || textstudentid <= 0)
                {
                    Response.Write("You must fill in the Semester box with a positive integer to register");
                }
                else if (!IsCourseIdExists(connStr, textcourseid) && !IsInstructorIdExists(connStr, textinstructorid) && !IsCourseIdExists(connStr, textcourseid) && !IsSemesterCodeExists(connStr, currsem))
                {
                    Response.Write($"Course ID {textcourseid}, Instructor ID {textinstructorid}, Course ID {textcourseid} and Semester Code {currsem} do not exist.");
                }
                else if (!IsStudentIdExists(connStr, textstudentid))
                {
                    Response.Write($"Student with ID {textstudentid} does not exist in the Student table.");
                }
                else if (!IsCourseIdExists(connStr, textcourseid))
                {
                    Response.Write($"Course with ID {textcourseid} does not exist in the Course table.");
                }
                else if (!IsInstructorIdExists(connStr, textinstructorid))
                {
                    Response.Write($"Instructor with ID {textinstructorid} does not exist in the Instructor table.");
                }
                else if (!IsSemesterCodeExists(connStr, currsem))
                {
                    Response.Write($"Semester with Code {currsem} does not exist in the Semester table.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("Procedures_Chooseinstructor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = textstudentid });
                    cmd.Parameters.Add(new SqlParameter("@instrucorID", SqlDbType.Int) { Value = textinstructorid }); //spelling mistake in @InstructorID
                    cmd.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = textcourseid });
                    cmd.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.VarChar, 40) { Value = currsem });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("InstructorChooseRedirect.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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

        static bool IsSemesterCodeExists(string connectionString, String semestercode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Semester WHERE semester_code=@SemesterCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SemesterCode", semestercode);

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