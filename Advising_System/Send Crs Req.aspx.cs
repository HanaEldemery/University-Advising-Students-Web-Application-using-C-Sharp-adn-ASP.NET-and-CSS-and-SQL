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
    public partial class Send_Crs_Req : System.Web.UI.Page
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

                int courseId1= Int16.Parse(courseId.Text);
                int studentId = (int)Session["sidret"];
                String type1 = type.Text;
                String comment1 = comment.Text;

                if (string.IsNullOrEmpty(type1) || string.IsNullOrEmpty(comment1))
                {
                    Response.Write("You must fill in all the boxes");
                }

                else if (!IsCrsCodeExists(connStr, courseId1))
                {
                    Response.Write("This course does not exist");
                }
                else
                {
                    SqlCommand crsReqProc = new SqlCommand("Procedures_StudentSendingCourseRequest", conn);
                    crsReqProc.CommandType = CommandType.StoredProcedure;
                    crsReqProc.Parameters.Add(new SqlParameter("@courseID", courseId1));
                    crsReqProc.Parameters.Add(new SqlParameter("@StudentID", studentId));
                    crsReqProc.Parameters.Add(new SqlParameter("@type", type1));
                    crsReqProc.Parameters.Add(new SqlParameter("@comment", comment1));

                    conn.Open();
                    crsReqProc.ExecuteNonQuery();
                    conn.Close();

                    Response.Redirect("Requests.aspx");
                }
            }
            catch (Exception a)
            {
                Response.Write("You must fill in the Course ID box with an integer");
            }
        }

        static bool IsCrsCodeExists(string connectionString, int crsCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Course WHERE course_id=@crsCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@crsCode", crsCode);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
    }
}