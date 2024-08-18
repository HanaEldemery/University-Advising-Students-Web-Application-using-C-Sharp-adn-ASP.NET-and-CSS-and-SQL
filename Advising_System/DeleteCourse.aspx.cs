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
    public partial class DeleteCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void delete_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int sid = Int16.Parse(studID.Text);
            String SCode = SemCode.Text;
            int course_id = Int16.Parse(Cid.Text);

            SqlCommand deleteproc = new SqlCommand("Procedures_AdvisorDeleteFromGP", conn);

            deleteproc.CommandType = CommandType.StoredProcedure;
            deleteproc.Parameters.Add(new SqlParameter("@studentID", sid));
            deleteproc.Parameters.Add(new SqlParameter("@sem_code", SCode));
            deleteproc.Parameters.Add(new SqlParameter("@courseID", course_id));


            conn.Open();
            deleteproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("Deleted Successfully!");

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}