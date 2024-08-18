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
    public partial class HoursApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void proccess_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int rId = Int16.Parse(requestId.Text);
            String curr_semCode = currSemCode.Text;


            SqlCommand CHRproc = new SqlCommand("Procedures_AdvisorApproveRejectCHRequest", conn);

            CHRproc.CommandType = CommandType.StoredProcedure;
            CHRproc.Parameters.Add(new SqlParameter("@requestID", rId));
            CHRproc.Parameters.Add(new SqlParameter("@current_sem_code", curr_semCode));


            conn.Open();
            CHRproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("Proccess completed!");

        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}