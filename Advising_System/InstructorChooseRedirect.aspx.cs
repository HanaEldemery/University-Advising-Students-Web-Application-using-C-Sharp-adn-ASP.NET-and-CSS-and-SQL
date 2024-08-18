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
    public partial class InstructorChooseRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retstudentid = (int)Session["sidret"];
            int retinstructorid = (int)Session["iidret"];
            int retcourseid = (int)Session["cidret"];
            string retcurrentsem = (string)Session["csemcode"];

            string sqlCommandText = "SELECT * FROM Student_Instructor_Course_take WHERE student_id=@StudentID AND course_id=@CourseID AND semester_code=@SemesterCode AND instructor_id=@InstructorID";
            conn.Open();
            SqlCommand list1 = new SqlCommand(sqlCommandText, conn);
            list1.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = retstudentid });
            list1.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = retcourseid });
            list1.Parameters.Add(new SqlParameter("@InstructorID", SqlDbType.Int) { Value = retinstructorid });
            list1.Parameters.Add(new SqlParameter("@SemesterCode", SqlDbType.VarChar, 40) { Value = retcurrentsem });
            //list1.CommandType = CommandType.Text;

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Student ID", typeof(int));
            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Instructor ID", typeof(int));
            datatable.Columns.Add("Semester Code", typeof(String));
            datatable.Columns.Add("Exam Type", typeof(String));
            datatable.Columns.Add("Grade", typeof(String));

            SqlDataReader reader = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())//reader.Read() && "student_id" == studentid && "course_id" == courseid)
            {
                int studentid1 = reader.GetInt32(reader.GetOrdinal("student_id"));
                int courseid1 = reader.GetInt32(reader.GetOrdinal("course_id"));
                int instructorid1 = reader.GetInt32(reader.GetOrdinal("instructor_id"));
                String semestercode1 = reader.GetString(reader.GetOrdinal("semester_code"));
                String examtype1 = reader.GetString(reader.GetOrdinal("exam_type"));
                String grade1;
                int gradeordinal = reader.GetOrdinal("grade");
                if (!reader.IsDBNull(gradeordinal))
                {
                    grade1 = reader.GetString(gradeordinal);
                }
                else
                {
                    grade1 = null;
                }

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Student ID"] = studentid1;
                rowsnew["Course ID"] = courseid1;
                rowsnew["Instructor ID"] = instructorid1;
                rowsnew["Semester Code"] = semestercode1;
                rowsnew["Exam Type"] = examtype1;
                rowsnew["Grade"] = grade1;

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
            Response.Redirect("InstructorChoose.aspx");
        }
    }
}