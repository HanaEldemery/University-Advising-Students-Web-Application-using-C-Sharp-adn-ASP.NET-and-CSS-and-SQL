<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Login.aspx.cs" Inherits="Advising_System.Student_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800;900&family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Student Login:"></asp:Label><br />
            Student ID:<asp:TextBox CssClass="input" ID="studentId" runat="server"></asp:TextBox>
            Password:<asp:TextBox ID="password" CssClass="input" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="login" Text="Login" />
            <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="back" Text="Back" />
        </div>
    </form>
</body>
</html>
