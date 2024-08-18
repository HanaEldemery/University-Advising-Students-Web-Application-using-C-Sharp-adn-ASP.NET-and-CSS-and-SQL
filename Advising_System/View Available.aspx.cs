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
    public partial class View_Available : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void viewAvailable(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String semCode1 = semCode.Text;
            Session["currcodeid"] = semCode1;

            if (string.IsNullOrEmpty(semCode1))
            {
                Response.Write("You must fill in the current semester code box");
            }
            else if (!IsSemCodeExists2(connStr, semCode1))
            {
                Response.Write("This Semester Code does not exist");
            }
            else
            {
                conn.Open();
                Response.Redirect("View Available 2.aspx");
                conn.Close();
            }
        }

        static bool IsSemCodeExists2(string connectionString, String semCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Semester WHERE semester_code=@semCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@semCode", semCode);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
    }
}