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
    public partial class ViewStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void view1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            int advisor_Id = (int)Session["advId"];
            String sMajor = major.Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand viewproc = new SqlCommand("Procedures_AdvisorViewAssignedStudents", conn))
                {

                    viewproc.CommandType = CommandType.StoredProcedure;
                    viewproc.Parameters.Add(new SqlParameter("@AdvisorID", advisor_Id));
                    viewproc.Parameters.Add(new SqlParameter("@major", sMajor));

                    conn.Open();


                    using (SqlDataReader reader = viewproc.ExecuteReader())
                    {
                        viewStud.DataSource = reader;
                        viewStud.DataBind();
                    }
                }

            }
            Response.Write("Table displayed");

        }

        protected void goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}