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
    public partial class Advisor_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void reg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String name_adv = name.Text;
            String pass = password.Text;
            String email_adv = email.Text;
            String office_adv = office.Text;

            SqlCommand registrationproc = new SqlCommand("Procedures_AdvisorRegistration", conn);

            registrationproc.CommandType = CommandType.StoredProcedure;
            registrationproc.Parameters.Add(new SqlParameter("@advisor_name", name_adv));
            registrationproc.Parameters.Add(new SqlParameter("@password", pass));
            registrationproc.Parameters.Add(new SqlParameter("@email", email_adv));
            registrationproc.Parameters.Add(new SqlParameter("@office", office_adv));



            SqlParameter advisorId = registrationproc.Parameters.Add("@Advisor_Id", SqlDbType.Int);
            advisorId.Direction = ParameterDirection.Output;

            conn.Open();
            registrationproc.ExecuteScalar();
            conn.Close();


            Response.Write("Thank you for Registering!" + " " + "Your ID is:" + advisorId.Value.ToString());

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}