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
    public partial class Admin_Add_Course : System.Web.UI.Page
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

                    string majorInput = major.Text;
                    string nameInput = name.Text;
                    int semesterInput = Convert.ToInt32(semester.Text);
                    int creditHoursInput = Convert.ToInt32(creditHours.Text);
                    bool isOfferedInput = isOffered.Checked;

                    SqlCommand courseAddproc = new SqlCommand("Procedures_AdminAddingCourse", conn);
                    courseAddproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseAddproc.Parameters.Add(new SqlParameter("@major", majorInput));
                    courseAddproc.Parameters.Add(new SqlParameter("@semester", semesterInput));
                    courseAddproc.Parameters.Add(new SqlParameter("@credit_hours", creditHoursInput));
                    courseAddproc.Parameters.Add(new SqlParameter("@name", nameInput));
                    courseAddproc.Parameters.Add(new SqlParameter("@is_offered", isOfferedInput));

                    courseAddproc.ExecuteNonQuery();

                    Response.Write("Added Course: " + nameInput);

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