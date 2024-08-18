<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Registration.aspx.cs" Inherits="Advising_System.Advisor_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Register<br />
        Name:<br />
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br />
        Password:<br />
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        <br />
        Email:<br />
        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <br />
        Office:<br />
        <asp:TextBox ID="office" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="signup" runat="server" onClick="reg" Text="Register" />
        <br />
        <br />
        <asp:Button ID="LoginPage" runat="server" Text="Log In" OnClick="Login_Click" />
    </form>
</body>
</html>
