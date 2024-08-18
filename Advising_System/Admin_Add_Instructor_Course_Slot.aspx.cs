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
    public partial class Admin_Add_Instructor_Course_Slot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["LoggedIn"]))
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
        protected void addInstructorLinkCourse(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string instructorInput = instructor.Text;
                    string courseInput = course.Text;
                    String slotInput = slot.Text;

                    SqlCommand courseDeleteproc = new SqlCommand("Procedures_AdminLinkInstructor", conn);
                    courseDeleteproc.CommandType = System.Data.CommandType.StoredProcedure;
                    courseDeleteproc.Parameters.Add(new SqlParameter("@cours_id", courseInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@instructor_id", instructorInput));
                    courseDeleteproc.Parameters.Add(new SqlParameter("@slot_id", slotInput));

                    courseDeleteproc.ExecuteNonQuery();

                    Response.Write("Linked Instructor With ID: " + instructorInput + " With Course With ID: " + courseInput + " On Slot With ID: " + slotInput);

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