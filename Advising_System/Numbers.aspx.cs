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
    public partial class Numbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retstudentid = (int)Session["sidret"];

            string sqlCommandText = "SELECT * FROM Student_Phone WHERE student_id=@student_id";
            conn.Open();
            SqlCommand list1 = new SqlCommand(sqlCommandText, conn);
            list1.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int) { Value = retstudentid });

            DataTable datatable = new DataTable();
            datatable.Columns.Add("Student ID", typeof(int));
            datatable.Columns.Add("Phone Number", typeof(String));

            SqlDataReader reader = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int studentid1 = reader.GetInt32(reader.GetOrdinal("student_id"));
                string phonenumber1 = reader.GetString(reader.GetOrdinal("phone_number"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Student ID"] = studentid1;
                rowsnew["Phone Number"] = phonenumber1;
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
            Response.Redirect("Student Telephone.aspx");
        }
    }
}