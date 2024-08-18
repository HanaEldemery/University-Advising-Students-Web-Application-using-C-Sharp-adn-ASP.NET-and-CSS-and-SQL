using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Student_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            try
            {


                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int studentId1 = Int32.Parse(studentId.Text);
                String password1 = password.Text;

                SqlCommand studentLoginSF = new SqlCommand("SELECT dbo.FN_StudentLogin(@Student_id,@password)", conn);
                studentLoginSF.CommandType = CommandType.Text;
                studentLoginSF.Parameters.AddWithValue("@Student_id", studentId1);
                studentLoginSF.Parameters.AddWithValue("@password", password1);

                conn.Open();
                int successBit = Convert.ToInt32(studentLoginSF.ExecuteScalar());
                conn.Close();

                if (successBit == 1)
                {
                    Session["sidret"] = studentId1;
                    Response.Redirect("Student.aspx");
                }
                else if (!IsStudentIdExists(connStr, studentId1))
                {
                    Response.Write("This Student ID does not exist");
                }
                else if (string.IsNullOrEmpty(password1))
                {
                    Response.Write("Please insert a password to login");
                }
                else
                {
                    Response.Write("Incorrect Password");
                }
            }
            catch (Exception a)
            {
                Response.Write("Please insert a student ID as an integer to login");
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

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Student Register Login.aspx");
        }
    }
}