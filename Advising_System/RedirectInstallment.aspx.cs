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
    public partial class RedirectInstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            DateTime retdate = (DateTime)Session["dateret"];
            int retstudentid = (int)Session["sidret"];

            string sqlCommandText = "SELECT * FROM Installment WHERE deadline=@DeadlineDe AND payment_id= (SELECT payment_id FROM Payment WHERE student_id=@StudentId)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlCommandText, conn);
            cmd.Parameters.Add(new SqlParameter("@DeadlineDe", SqlDbType.DateTime) { Value = retdate });
            cmd.Parameters.Add(new SqlParameter("@StudentId", SqlDbType.Int) { Value = retstudentid });

            DataTable datatable = new DataTable();

            datatable.Columns.Add("Payment ID", typeof(int));
            datatable.Columns.Add("Start Date", typeof(DateTime));
            datatable.Columns.Add("Deadline", typeof(DateTime));
            datatable.Columns.Add("Amount", typeof(int));
            datatable.Columns.Add("Status", typeof(String));

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                int idofpayment = reader.GetInt32(reader.GetOrdinal("payment_id"));
                DateTime startingdate = reader.GetDateTime(reader.GetOrdinal("startdate"));
                DateTime datedeadline = reader.GetDateTime(reader.GetOrdinal("deadline"));
                int theamount = reader.GetInt32(reader.GetOrdinal("amount"));
                String thestatus = reader.GetString(reader.GetOrdinal("status"));

                DataRow rowsnew = datatable.NewRow();
                datatable.Rows.Add(rowsnew);
                rowsnew["Payment ID"] = idofpayment;
                rowsnew["Start Date"] = startingdate;
                rowsnew["Deadline"] = datedeadline;
                rowsnew["Amount"] = theamount;
                rowsnew["Status"] = thestatus;
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
            Response.Redirect("NotPaidInst.aspx");
        }
    }
}