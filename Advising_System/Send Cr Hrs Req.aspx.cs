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
    public partial class Send_Cr_Hrs_Req : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }

        protected void send(object sender, EventArgs e)
        {
            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int studentId = (int)Session["sidret"];
                int crHrs1 = Int16.Parse(crHrs.Text);
                String type1 = type.Text;
                String comment1 = comment.Text;

                if (string.IsNullOrEmpty(type1) || string.IsNullOrEmpty(comment1))
                {
                    Response.Write("You must fill in all the boxes");
                }
                else if (crHrs1 <= 0)
                {
                    Response.Write("You must fill in the Credit Hours box with a positive integer");
                }
                else
                {
                    SqlCommand crHrsProc = new SqlCommand("Procedures_StudentSendingCHRequest", conn);
                    crHrsProc.CommandType = CommandType.StoredProcedure;
                    crHrsProc.Parameters.Add(new SqlParameter("@StudentID", studentId));
                    crHrsProc.Parameters.Add(new SqlParameter("@credit_hours", crHrs1));
                    crHrsProc.Parameters.Add(new SqlParameter("@type", type1));
                    crHrsProc.Parameters.Add(new SqlParameter("@comment", comment1));

                    conn.Open();
                    crHrsProc.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("Requests 2.aspx");
                }
            }
            catch (Exception a)
            {
                Response.Write("You must fill in the Credit Hours box with an integer");
            }
        }
    }
}