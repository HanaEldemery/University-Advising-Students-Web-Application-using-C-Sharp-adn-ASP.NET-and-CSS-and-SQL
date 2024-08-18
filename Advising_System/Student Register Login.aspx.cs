using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Student_Register_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            Response.Redirect("Student Registration.aspx");
        }

        protected void login(object sender, EventArgs e)
        {
            Response.Redirect("Student Login.aspx");
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}