<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCourse.aspx.cs" Inherits="Advising_System.DeleteCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Student ID:<br />
            <asp:TextBox ID="studID" runat="server"></asp:TextBox>
            <br />
            Enter Semester Code:<br />
            <asp:TextBox ID="SemCode" runat="server"></asp:TextBox>
            <br />
            Enter Course ID:<br />
            <asp:TextBox ID="Cid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click" />
            <br />
            <br />
            <asp:Button ID="back" runat="server" Text="Go Back" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
