<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Advising_System.AdminLogin" %>

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
    <div id="LoginBody">
        <form id="form1" runat="server">
            <div id="adminLoginHeader">
                Admin Log In
            </div>
            <asp:Label ID="ErrorMessageLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
            <div id="inputsDiv">
                <div class="inputDiv">
                    <label for="type">Username</label>
                    <asp:TextBox ID="username" type="text" runat="server"></asp:TextBox>
                </div>
                <div class="inputDiv">
                    <label for="type">Password</label>
                    <asp:TextBox ID="password" type="password" runat="server"></asp:TextBox>
                </div>
            </div>
            <div id="loginButton">
                <asp:Button ID="signin" OnClick="login" runat="server"  Text="Log In" />
            </div>
        </form>
    </div>
</body>
</html>
