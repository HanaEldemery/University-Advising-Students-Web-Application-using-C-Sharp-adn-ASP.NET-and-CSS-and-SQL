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
    public partial class RedirectGradPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retstudentid = (int)Session["sidret"];

            string sqlCommandText = "SELECT * FROM FN_StudentViewGP(@StudentID)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, conn);
            cmd.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = retstudentid });

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Student Name", typeof(String));
            datatable.Columns.Add("Plan ID", typeof(int));
            datatable.Columns.Add("Semester Code", typeof(String));
            //datatable.Columns.Add("Semester Credit Hours", typeof(object)).AllowDBNull = true;
            datatable.Columns.Add("Semester Credit Hours", typeof(int));
            datatable.Columns.Add("Expected Graduation Date", typeof(DateTime));
            datatable.Columns.Add("Advisor ID", typeof(int));
            datatable.Columns.Add("Student ID", typeof(int));
            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Course Name", typeof(String));

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                String nameofstudent = reader.GetString(reader.GetOrdinal("Student_name"));
                int idofplan = reader.GetInt32(reader.GetOrdinal("plan_id"));
                String codeofsem = reader.GetString(reader.GetOrdinal("semester_code"));
                //int creditsofsem = reader.GetInt32(reader.GetOrdinal("semester_credit_hours")); //can be null
                DateTime expectedgrad = reader.GetDateTime(reader.GetOrdinal("expected_grad_date")); //can be null
                int idadvisor = reader.GetInt32(reader.GetOrdinal("advisor_id"));
                int idstudent = reader.GetInt32(reader.GetOrdinal("student_id"));
                int idcourse = reader.GetInt32(reader.GetOrdinal("course_id"));
                String nameofcourse = reader.GetString(reader.GetOrdinal("name"));

                int creditsofsem;
                int ordinalcreditsofsem = reader.GetOrdinal("semester_credit_hours");
                if (!reader.IsDBNull(ordinalcreditsofsem))
                {
                    creditsofsem = reader.GetInt32(ordinalcreditsofsem);
                }
                else
                {
                    creditsofsem = 0;
                }

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Student Name"] = nameofstudent;
                rowsnew["Plan ID"] = idofplan;
                rowsnew["Semester Code"] = codeofsem;
                rowsnew["Semester Credit Hours"] = creditsofsem;
                rowsnew["Expected Graduation Date"] = expectedgrad;
                rowsnew["Advisor ID"] = idadvisor;
                rowsnew["Student ID"] = idstudent;
                rowsnew["Course ID"] = idcourse;
                rowsnew["Course Name"] = nameofcourse;
            }
            GridView gridView = new GridView();
            gridView.DataSource = datatable;
            gridView.DataBind();

            gridView.Width = Unit.Pixel(1000);
            gridView.Height = Unit.Pixel(500);

            gridView.Visible = true;

            form1.Controls.Add(gridView);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}