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
    public partial class CourseApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ApprovalReq_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int rId = Int16.Parse(reqId.Text);
            String currSemCode = semCode.Text;


            SqlCommand Appproc = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn);

            Appproc.CommandType = CommandType.StoredProcedure;
            Appproc.Parameters.Add(new SqlParameter("@requestID", rId));
            Appproc.Parameters.Add(new SqlParameter("@current_semester_code", currSemCode));


            conn.Open();
            Appproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("Proccess completed!");

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}