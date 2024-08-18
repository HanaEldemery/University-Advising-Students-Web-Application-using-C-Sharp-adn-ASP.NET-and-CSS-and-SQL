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
    public partial class Admin_Add_Student_Advisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
        protected void addStudentAdvisor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    int studentIdInput = Convert.ToInt32(student.Text);
                    int advisorIdInput = Convert.ToInt32(advisor.Text);

                    SqlCommand courseDeleteproc = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);
                    courseDeleteproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseDeleteproc.Parameters.Add(new SqlParameter("@studentID", studentIdInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@advisorID", advisorIdInput));

                    courseDeleteproc.ExecuteNonQuery();

                    Response.Write("Added Advisor With ID: " + advisorIdInput + " As Advisor To Student With ID: " + studentIdInput);

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