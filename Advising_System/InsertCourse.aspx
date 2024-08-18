<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCourse.aspx.cs" Inherits="Advising_System.InsertCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Student ID:<br />
            <asp:TextBox ID="studentId" runat="server"></asp:TextBox>
            <br />
            Enter Semester Code:<br />
            <asp:TextBox ID="Sem_code" runat="server"></asp:TextBox>
            <br />
            Enter Course Name:<br />
            <asp:TextBox ID="Course_name" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Insert_Course" runat="server" OnClick="insert"  Text="Insert" />
            <br />
            <br />
            <asp:Button ID="back" runat="server" Text="Go Back" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
