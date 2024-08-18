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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    int usernameInput = Convert.ToInt32(username.Text);
                    String pass = password.Text;

                    if (usernameInput == 1 && pass == "password")
                    {
                        Session["LoggedIn"] = true;
                        Response.Redirect("AdminHomePage.aspx");
                    }
                    else
                    {
                        ErrorMessageLabel.Text = "Wrong Credentials!";
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}