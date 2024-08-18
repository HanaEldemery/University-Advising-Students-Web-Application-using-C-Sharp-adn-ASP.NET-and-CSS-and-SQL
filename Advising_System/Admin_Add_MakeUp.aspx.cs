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
    public partial class Admin_Add_MakeUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
        protected void addMakeUp(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    String typeInput = type.Text;
                    String dateInput = date.Text;
                    int courseIdInput = Convert.ToInt32(courseId.Text);

                    SqlCommand courseDeleteproc = new SqlCommand("Procedures_AdminAddExam", conn);
                    courseDeleteproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseDeleteproc.Parameters.Add(new SqlParameter("@Type", typeInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@date", dateInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@courseID", courseIdInput));

                    courseDeleteproc.ExecuteNonQuery();

                    Response.Write("Added Make Up Exam To Course With ID: " + courseIdInput);

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