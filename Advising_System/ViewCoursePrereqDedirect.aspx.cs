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
    public partial class ViewCoursePrereqDedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string sqlCommandText = "SELECT * FROM view_Course_prerequisites";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, conn);

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Course Name", typeof(String));
            datatable.Columns.Add("Major", typeof(String));
            datatable.Columns.Add("Is Offered", typeof(bool));
            datatable.Columns.Add("Credit Hours", typeof(int));
            datatable.Columns.Add("Semester", typeof(int));
            datatable.Columns.Add("Prereq Course ID", typeof(int));
            datatable.Columns.Add("Prereq Course Name", typeof(String));

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int idofcourse = reader.GetInt32(reader.GetOrdinal("course_id"));
                String nameofcourse = reader.GetString(reader.GetOrdinal("name"));
                String nameofmajor = reader.GetString(reader.GetOrdinal("major"));
                bool offeredornot = reader.GetBoolean(reader.GetOrdinal("is_offered"));
                int credits = reader.GetInt32(reader.GetOrdinal("credit_hours"));
                int semno = reader.GetInt32(reader.GetOrdinal("semester"));
                int prereqid = reader.GetInt32(reader.GetOrdinal("preRequsite_course_id"));
                String prereqname = reader.GetString(reader.GetOrdinal("preRequsite_course_name"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Course ID"] = idofcourse;
                rowsnew["Course Name"] = nameofcourse;
                rowsnew["Major"] = nameofmajor;
                rowsnew["Is Offered"] = offeredornot;
                rowsnew["Credit Hours"] = credits;
                rowsnew["Semester"] = semno;
                rowsnew["Prereq Course ID"] = prereqid;
                rowsnew["Prereq Course Name"] = prereqname;
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