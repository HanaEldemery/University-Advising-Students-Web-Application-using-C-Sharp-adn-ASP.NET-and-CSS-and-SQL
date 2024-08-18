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
    public partial class RedirectFirstMakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retstudentid = (int)Session["sidret"];
            int retcourseid = (int)Session["cidret"];

            string sqlCommandText = "SELECT * FROM Exam_Student WHERE student_id=@StudentID AND course_id=@CourseID";
            conn.Open();
            SqlCommand list1 = new SqlCommand(sqlCommandText, conn);
            list1.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = retstudentid });
            list1.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = retcourseid });
            //list1.CommandType = CommandType.Text;

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Exam ID", typeof(int));
            datatable.Columns.Add("Student ID", typeof(int));
            datatable.Columns.Add("Course ID", typeof(int));

            SqlDataReader reader = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())//reader.Read() && "student_id" == studentid && "course_id" == courseid)
            {
                int studentid1 = reader.GetInt32(reader.GetOrdinal("student_id"));
                int courseid1 = reader.GetInt32(reader.GetOrdinal("course_id"));
                int examid1 = reader.GetInt32(reader.GetOrdinal("exam_id"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Student ID"] = studentid1;
                rowsnew["Course ID"] = courseid1;
                rowsnew["Exam ID"] = examid1;
            }
            GridView gridView = new GridView();
            gridView.DataSource = datatable;
            gridView.DataBind();

            gridView.Width = Unit.Pixel(1000);
            gridView.Height = Unit.Pixel(500);

            gridView.Visible = true;

            form1.Controls.Add(gridView);
            if (datatable == null || datatable.Rows.Count == 0)
            {
                Response.Write("Not Eligible for First Makeup");
            }
            else
            {
                Response.Write("Eligible for First Makeup");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FIrstMakeup.aspx");
        }
    }
}