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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            try
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int advisor_Id = Int16.Parse(username.Text);
                String pass = password.Text;

                SqlCommand loginproc = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@advisor_Id, @password)", conn);

                // Add parameters
                loginproc.Parameters.Add(new SqlParameter("@advisor_Id", advisor_Id));
                loginproc.Parameters.Add(new SqlParameter("@password", pass));

                conn.Open();

                bool success = Convert.ToBoolean(loginproc.ExecuteScalar());

                conn.Close();

                if (success)
                {
                    Session["advId"] = advisor_Id;
                    Response.Write("Welcome!");
                    Response.Redirect("Homepage.aspx");
                }
                else
                {
                    Response.Write("Invalid credentials. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }
    }
}