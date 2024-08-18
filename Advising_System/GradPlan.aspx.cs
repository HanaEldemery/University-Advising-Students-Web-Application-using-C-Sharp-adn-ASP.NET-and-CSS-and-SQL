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
    public partial class GradPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int adv_id = (int)Session["advId"];
            String sem_code = semCode.Text;
            DateTime date = DateTime.Parse(gradDate.Text);
            int semCredHours = Int16.Parse(sem_credHours.Text);
            int stud_id = Int16.Parse(studentId.Text);

            SqlCommand GPproc = new SqlCommand("Procedures_AdvisorCreateGP", conn);

            GPproc.CommandType = CommandType.StoredProcedure;
            GPproc.Parameters.Add(new SqlParameter("@Semester_code", sem_code));
            GPproc.Parameters.Add(new SqlParameter("@expected_graduation_date", date));
            GPproc.Parameters.Add(new SqlParameter("@sem_credit_hours", semCredHours));
            GPproc.Parameters.Add(new SqlParameter("@advisor_id", adv_id));
            GPproc.Parameters.Add(new SqlParameter("@student_id", stud_id));


            conn.Open();
            GPproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("GradPlan inserted successfully!");






        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}