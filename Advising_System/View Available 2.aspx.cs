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
    public partial class View_Available_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String semcode = (String)Session["currcodeid"];

            string sqlCommandText = "SELECT * FROM FN_SemsterAvailableCourses(@semstercode)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, conn);
            cmd.Parameters.Add(new SqlParameter("@semstercode", SqlDbType.NVarChar) { Value = semcode });


            DataTable datatable = new DataTable();

            datatable.Columns.Add("Course Name", typeof(String));
            datatable.Columns.Add("Course ID", typeof(int));

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                String nameofcourse = reader.GetString(reader.GetOrdinal("name"));
                int idofcourse = reader.GetInt32(reader.GetOrdinal("course_id"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Course Name"] = nameofcourse;
                rowsnew["Course ID"] = idofcourse;
            }
            GridView gridView = new GridView();
            gridView.DataSource = datatable;
            gridView.DataBind();

            gridView.Width = Unit.Pixel(1000);
            gridView.Height = Unit.Pixel(500);

            gridView.Visible = true;

            form1.Controls.Add(gridView);
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("View Available.aspx");
        }
    }
}