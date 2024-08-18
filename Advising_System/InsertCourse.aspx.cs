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
    public partial class InsertCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insert(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int stud_id = Int16.Parse(studentId.Text);
            String semCode = Sem_code.Text;
            String courseName = Course_name.Text;

            SqlCommand AddCourseproc = new SqlCommand("Procedures_AdvisorAddCourseGP", conn);

            AddCourseproc.CommandType = CommandType.StoredProcedure;
            AddCourseproc.Parameters.Add(new SqlParameter("@student_id", stud_id));
            AddCourseproc.Parameters.Add(new SqlParameter("@Semester_code", semCode));
            AddCourseproc.Parameters.Add(new SqlParameter("@course_name", courseName));



            conn.Open();
            AddCourseproc.ExecuteNonQuery();
            conn.Close();

            Response.Write("Course inserted in plan successfully!");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}