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
    public partial class NotPaidInst : System.Web.UI.Page
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

                if (textstudentid <= 0)
                {
                    Response.Write("You must fill in the Semester box with a positive integer to register");
                }
                else if (!IsStudentIdExists(connStr, textstudentid))
                {
                    Response.Write($"Student with ID {textstudentid} does not exist in the Student table.");
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@student_ID)", conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@student_id", textstudentid);

                    DateTime dateResult = Convert.ToDateTime(cmd.ExecuteScalar());

                    Session["dateret"] = dateResult;
                    Response.Redirect("RedirectInstallment.aspx");
                
                }
            }
            catch (Exception ex)
            {
                Response.Write("You don't have any unpaid installments");
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}