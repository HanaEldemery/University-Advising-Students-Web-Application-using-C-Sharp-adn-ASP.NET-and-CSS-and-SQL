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
    public partial class CoursesC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand list1 = new SqlCommand("SELECT * FROM Courses_MakeupExams", conn);
            list1.CommandType = CommandType.Text;
            conn.Open();
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Exam ID", typeof(int));
            datatable.Columns.Add("Date", typeof(DateTime));
            datatable.Columns.Add("Type", typeof(String));
            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Course Name", typeof(String));
            datatable.Columns.Add("Course Semester", typeof(int));

            SqlDataReader sqlr = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlr.Read())
            {
                int idofcourse = sqlr.GetInt32(sqlr.GetOrdinal("course_id"));
                String nameofcourse = sqlr.GetString(sqlr.GetOrdinal("name"));
                int semesterofcourse = sqlr.GetInt32(sqlr.GetOrdinal("semester"));
                DateTime dateofexam = sqlr.GetDateTime(sqlr.GetOrdinal("date"));
                String typeofexam = sqlr.GetString(sqlr.GetOrdinal("type"));
                int examid = sqlr.GetInt32(sqlr.GetOrdinal("exam_id"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Exam ID"] = examid;
                rowsnew["Date"] = dateofexam;
                rowsnew["Type"] = typeofexam;
                rowsnew["Course ID"] = idofcourse;
                rowsnew["Course Name"] = nameofcourse;
                rowsnew["Course Semester"] = semesterofcourse;
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