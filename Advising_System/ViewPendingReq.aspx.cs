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
    public partial class ViewPendingReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

                int advisor_Id = (int)Session["advId"];



                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand pendingproc = new SqlCommand("Procedures_AdvisorViewPendingRequests", conn))
                    {

                        pendingproc.CommandType = CommandType.StoredProcedure;
                        pendingproc.Parameters.Add(new SqlParameter("@Advisor_ID", advisor_Id));

                        conn.Open();


                        using (SqlDataReader reader = pendingproc.ExecuteReader())
                        {
                            viewPenReq.DataSource = reader;
                            viewPenReq.DataBind();
                        }
                    }

                }
                Response.Write("Table displayed");
            }
        }





        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}