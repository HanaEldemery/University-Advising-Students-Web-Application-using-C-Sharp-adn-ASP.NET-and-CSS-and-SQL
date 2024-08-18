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
    public partial class Admin_Add_Semester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
        protected void addSemester(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string startDateInput = startDate.Text;
                    string endDateInput = endDate.Text;
                    String semesterCodeInput = semesterCode.Text;

                    SqlCommand courseDeleteproc = new SqlCommand("AdminAddingSemester", conn);
                    courseDeleteproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseDeleteproc.Parameters.Add(new SqlParameter("@start_date", startDateInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@end_date", endDateInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@semester_code", semesterCodeInput));

                    courseDeleteproc.ExecuteNonQuery();

                    Response.Write("Added Semester With Code: " + semesterCodeInput);

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