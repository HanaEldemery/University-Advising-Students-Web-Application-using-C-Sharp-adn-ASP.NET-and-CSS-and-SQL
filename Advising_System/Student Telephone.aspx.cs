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
    public partial class Student_Telephone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add(object sender, EventArgs e)
        {
            try
            {

                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                int studentId = (int)Session["sidret"];
                String phoneNumber1 = phoneNumber.Text;

                if (string.IsNullOrEmpty(phoneNumber1))
                {
                    Response.Write("You must fill in the Phone Number box");
                }
                else 
                {
                    SqlCommand addPhoneProc = new SqlCommand("Procedures_StudentaddMobile", conn);
                    addPhoneProc.CommandType = CommandType.StoredProcedure;
                    addPhoneProc.Parameters.Add(new SqlParameter("@StudentID", studentId));
                    addPhoneProc.Parameters.Add(new SqlParameter("@mobile_number", phoneNumber1));

                    conn.Open();
                    addPhoneProc.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("Numbers.aspx");

                }
            }
            catch(Exception a)
            {
                Response.Write("You can't add the same phone number twice");
            }
            

        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}