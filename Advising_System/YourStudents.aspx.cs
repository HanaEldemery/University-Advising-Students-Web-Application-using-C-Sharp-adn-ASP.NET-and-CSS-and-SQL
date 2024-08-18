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
    public partial class YourStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int adv_id = (int)Session["advId"];
            if (!IsValidAdvisor(adv_id))
            {
                Response.Write("Invalid ID entered");
                Response.Redirect("YourStudents");
            }

            if (!IsPostBack)
            {
                String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);


                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Student WHERE advisor_id = @adv_id", connection);
                    command.Parameters.AddWithValue("@adv_id", adv_id);
                    connection.Open();

                    viewStud.DataSource = command.ExecuteReader();
                    viewStud.DataBind();
                }
            }
        }


        static bool IsValidAdvisor(int advisorID)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Advisor WHERE advisor_id = @adv_id", connection))
                {
                    command.Parameters.AddWithValue("@adv_id", advisorID);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}