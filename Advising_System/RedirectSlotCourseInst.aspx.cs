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
    public partial class RedirectSlotCourseInst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retcourseid = (int)Session["cidret"];
            int retinstructorid = (int)Session["iidret"];

            string sqlCommandText = "SELECT * FROM FN_StudentViewSlot(@CourseID, @InstructorID)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, conn);
            cmd.Parameters.Add(new SqlParameter("@CourseID", SqlDbType.Int) { Value = retcourseid });
            cmd.Parameters.Add(new SqlParameter("@InstructorID", SqlDbType.Int) { Value = retinstructorid });

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Course Name", typeof(String));
            datatable.Columns.Add("Instructor Name", typeof(String));
            datatable.Columns.Add("Slot ID", typeof(int));
            datatable.Columns.Add("Day", typeof(String));
            datatable.Columns.Add("Time", typeof(String));
            datatable.Columns.Add("Location", typeof(String));
            datatable.Columns.Add("Instructor ID", typeof(int));

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int idofcourse = reader.GetInt32(reader.GetOrdinal("CourseID"));
                String nameofcourse = reader.GetString(reader.GetOrdinal("Course"));
                String nameofinstructor = reader.GetString(reader.GetOrdinal("Instructor"));
                int idofslot = reader.GetInt32(reader.GetOrdinal("slot_id"));
                String theday = reader.GetString(reader.GetOrdinal("day"));
                String thetime = reader.GetString(reader.GetOrdinal("time"));
                String thelocation = reader.GetString(reader.GetOrdinal("location"));
                int idofinstructor = reader.GetInt32(reader.GetOrdinal("instructor_id"));

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
            Response.Redirect("SlotCourseInst.aspx");
        }
    }
}