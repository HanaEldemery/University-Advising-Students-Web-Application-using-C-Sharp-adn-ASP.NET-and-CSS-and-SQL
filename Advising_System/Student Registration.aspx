<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Registration.aspx.cs" Inherits="Advising_System.Student_Registration" %>

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
            First Name:<asp:TextBox CssClass="input" ID="firstName" runat="server"></asp:TextBox>
            Last Name:<asp:TextBox CssClass="input" ID="lastName" runat="server"></asp:TextBox>
            Password:<asp:TextBox CssClass="input" ID="password" runat="server"></asp:TextBox>
            Faculty:<asp:TextBox CssClass="input" ID="faculty" runat="server"></asp:TextBox>
            Email:<asp:TextBox CssClass="input" ID="email" runat="server"></asp:TextBox>
            Major:<asp:TextBox CssClass="input" ID="major" runat="server"></asp:TextBox>
            Semester:<asp:TextBox CssClass="input" ID="semester" runat="server"></asp:TextBox>
            <div class="Ayhaga">
            <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="register" Text="Register" />
            <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="back" Text="Back" />
            </div>
        </div>
    </form>
</body>
</html>
