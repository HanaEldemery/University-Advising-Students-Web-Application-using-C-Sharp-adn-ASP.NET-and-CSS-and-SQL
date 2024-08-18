<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="Advising_System.ViewStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        Enter desired Major:<br />
        <asp:TextBox ID="major" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="view1" runat="server" Text="View" OnClick="view1_Click" />
        <br />
        <br />
        <asp:GridView ID="viewStud" runat="server"  AutoGenerateColumns="True"></asp:GridView>
        <br />
        <asp:Button ID="goback" runat="server" Text="Go Back" OnClick="goback_Click" />
        <br />
    </form>
</body>
</html>
