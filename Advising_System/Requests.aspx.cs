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
    public partial class Requests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int retstudentid = (int)Session["sidret"];

            string sqlCommandText = "SELECT * FROM Request WHERE student_id=@student_id";
            conn.Open();
            SqlCommand list1 = new SqlCommand(sqlCommandText, conn);
            list1.Parameters.Add(new SqlParameter("@student_id", SqlDbType.Int) { Value = retstudentid });

            DataTable datatable = new DataTable();
            datatable.Columns.Add("Request ID", typeof(int));
            datatable.Columns.Add("Type", typeof(String));
            datatable.Columns.Add("Comment", typeof(String));
            datatable.Columns.Add("Status", typeof(String));
            datatable.Columns.Add("Credit Hours", typeof(int));
            datatable.Columns.Add("Course ID", typeof(int));
            datatable.Columns.Add("Student ID", typeof(int));
            datatable.Columns.Add("Advisor ID", typeof(int));

            SqlDataReader reader = list1.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int reqid = reader.GetInt32(reader.GetOrdinal("request_id"));
                string typ = reader.GetString(reader.GetOrdinal("type"));
                string comm = reader.GetString(reader.GetOrdinal("comment"));
                string stat = reader.GetString(reader.GetOrdinal("status"));

                int crhrs;
                int ordinalcrhrs = reader.GetOrdinal("credit_hours");
                if (!reader.IsDBNull(ordinalcrhrs))
                {
                    crhrs = reader.GetInt32(ordinalcrhrs);
                }
                else
                {
                    crhrs = 0;
                }

                int cid;
                int ordinalcid = reader.GetOrdinal("credit_hours");
                if (!reader.IsDBNull(ordinalcid))
                {
                    cid = reader.GetInt32(ordinalcid);
                }
                else
                {
                    cid = 0;
                }
                
                int sid = reader.GetInt32(reader.GetOrdinal("student_id"));

                int aid;
                int ordinalaid = reader.GetOrdinal("advisor_id");
                if (!reader.IsDBNull(ordinalaid))
                {
                    aid = reader.GetInt32(ordinalaid);
                }
                else
                {
                    aid = 0;
                }

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Request ID"] = reqid;
                rowsnew["Type"] = typ;
                rowsnew["Comment"] = comm;
                rowsnew["Status"] = stat;
                rowsnew["Credit Hours"] = crhrs;
                rowsnew["Course ID"] = cid;
                rowsnew["Student ID"] = sid;
                rowsnew["Advisor ID"] = aid;
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
            Response.Redirect("Send Crs Req.aspx");
        }
    }
}