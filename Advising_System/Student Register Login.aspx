<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Register Login.aspx.cs" Inherits="Advising_System.Student_Register_Login" %>

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
            <h1>
                Hi student!
                What would you like to do?
            </h1>
            <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="register" Text="Register" />
            <br />
            <asp:Button ID="Button2" CssClass="button" runat="server" OnClick="login" Text="Login" />
            <br />
            <asp:Button ID="Button3" CssClass="button" runat="server" OnClick="back" Text="Back" />
            </div>
    </form>
</body>
</html>
