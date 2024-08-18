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
    public partial class AllReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);


                int advisor_id = (int)(Session["advId"]);

                SqlCommand Reqproc = new SqlCommand("SELECT * FROM dbo.FN_Advisors_Requests(@advisor_id)", conn);
                Reqproc.Parameters.AddWithValue("@advisor_id", advisor_id);

                SqlDataAdapter da = new SqlDataAdapter(Reqproc);
                DataTable dt = new DataTable();

                conn.Open();
                da.Fill(dt);
                conn.Close();

                requests.DataSource = dt;
                requests.DataBind();
            }
        }


        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");

        }
    }
}