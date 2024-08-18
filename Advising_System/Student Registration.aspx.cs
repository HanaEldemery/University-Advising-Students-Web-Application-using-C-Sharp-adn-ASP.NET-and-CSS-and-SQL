using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Advising_System
{
    public partial class Student_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Student Registration: "); 
        }

        protected void register(object sender, EventArgs e)
        {
            try
            {
                string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
                SqlConnection conn = new SqlConnection(connStr);

                String firstName1 = firstName.Text;
                String lastName1 = lastName.Text;
                String password1 = password.Text;
                String faculty1 = faculty.Text;
                String email1 = email.Text;
                String major1 = major.Text;
                int semester1 = Int16.Parse(semester.Text);

                if (string.IsNullOrEmpty(firstName1) || string.IsNullOrEmpty(lastName1) || string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(faculty1) || string.IsNullOrEmpty(email1) || string.IsNullOrEmpty(major1))
                {
                    Response.Write("You must fill in all the boxes to register");
                }
                else if (semester1<=0)
                {
                    Response.Write("You must fill in the Semester box with a positive integer to register");
                }
                else
                {
                    SqlCommand studentRegistrationProc = new SqlCommand("Procedures_StudentRegistration", conn);
                    studentRegistrationProc.CommandType = CommandType.StoredProcedure;
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@first_name", firstName1));
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@last_name", lastName1));
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@password", password1));
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@faculty", faculty1));
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@email", email1));
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@major", major1));
                    studentRegistrationProc.Parameters.Add(new SqlParameter("@semester", semester1));

                    SqlParameter studentId = studentRegistrationProc.Parameters.Add("@Student_id", SqlDbType.Int);
                    studentId.Direction = ParameterDirection.Output;

                    conn.Open();
                    studentRegistrationProc.ExecuteNonQuery();
                    conn.Close();

                    Session["sidret"] = studentId.Value;
                    Response.Redirect("Student.aspx");
                }
            }
            catch(Exception a)
            {
                Response.Write("You must fill in the Semester box with an integer to register");
            }
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Student Register Login.aspx");
        }
    }
}