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
    public partial class UpdateGradDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void updateDate_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            DateTime dt = DateTime.Parse(gradDate.Text);
            int studentID = Int16.Parse(studId.Text);


            SqlCommand Updateproc = new SqlCommand("Procedures_AdvisorUpdateGP", conn);

            Updateproc.CommandType = CommandType.StoredProcedure;
            Updateproc.Parameters.Add(new SqlParameter("@expected_grad_date", dt));
            Updateproc.Parameters.Add(new SqlParameter("@studentID", studentID));



            conn.Open();
            Updateproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("Updated successfully!");

        }

        protected void goback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}