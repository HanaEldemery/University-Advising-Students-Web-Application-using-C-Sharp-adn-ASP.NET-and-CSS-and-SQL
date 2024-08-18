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
    public partial class CoursesSlotsIns : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand list1 = new SqlCommand("SELECT * FROM Courses_Slots_Instructor", conn);
            list1.CommandType = CommandType.Text;
            conn.Open();

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Course Name", typeof(String));
            datatable.Columns.Add("Instructor Name", typeof(String));
            datatable.Columns.Add("Slot ID", typeof(int));
            datatable.Columns.Add("Day", typeof(String));
            datatable.Columns.Add("Time", typeof(String));
            datatable.Columns.Add("Location", typeof(String));
            datatable.Columns.Add("Instructor ID", typeof(int));

            SqlDataReader sqlr = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (sqlr.Read())
            {
                int idofcourse = sqlr.GetInt32(sqlr.GetOrdinal("CourseID"));
                String nameofcourse = sqlr.GetString(sqlr.GetOrdinal("Course"));
                String nameofinstructor = sqlr.GetString(sqlr.GetOrdinal("Instructor"));
                int idofslot = sqlr.GetInt32(sqlr.GetOrdinal("slot_id"));
                String theday = sqlr.GetString(sqlr.GetOrdinal("day"));
                String thetime = sqlr.GetString(sqlr.GetOrdinal("time"));
                String thelocation = sqlr.GetString(sqlr.GetOrdinal("location"));
                int idofinstructor = sqlr.GetInt32(sqlr.GetOrdinal("instructor_id"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Course ID"] = idofcourse;
                rowsnew["Course Name"] = nameofcourse;
                rowsnew["Instructor Name"] = nameofinstructor;
                rowsnew["Slot ID"] = idofslot;
                rowsnew["Day"] = theday;
                rowsnew["Time"] = thetime;
                rowsnew["Location"] = thelocation;
                rowsnew["Instructor ID"] = idofinstructor;
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