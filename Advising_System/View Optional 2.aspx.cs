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
    public partial class View_Optional_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retstudentid = (int)Session["sidret"];
            String retcrs = (String)Session["currcodeid"];

            string sqlCommandText = "Procedures_ViewOptionalCourse";
            conn.Open();
            SqlCommand list1 = new SqlCommand(sqlCommandText, conn);
            list1.CommandType = CommandType.StoredProcedure;
            list1.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int) { Value = retstudentid });
            list1.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.NVarChar) { Value = retcrs });

            DataTable datatable = new DataTable();
            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Course Name", typeof(String));

            SqlDataReader reader = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int crsid1 = reader.GetInt32(reader.GetOrdinal("course_id"));
                string crsname1 = reader.GetString(reader.GetOrdinal("name"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Course ID"] = crsid1;
                rowsnew["Course Name"] = crsname1;
            }
            GridView gridView = new GridView();
            gridView.DataSource = datatable;
            gridView.DataBind();

            gridView.Width = Unit.Pixel(500);
            gridView.Height = Unit.Pixel(500);

            gridView.Visible = true;

            form1.Controls.Add(gridView);
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("View Optional.aspx");
        }
    }
}