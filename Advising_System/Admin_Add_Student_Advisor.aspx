<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Add_Student_Advisor.aspx.cs" Inherits="Advising_System.Admin_Add_Student_Advisor" %>

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
    <form id="form3" runat="server">
        <asp:Button ID="home" CssClass="button" runat="server" OnClick="backHomeFn" Text="Home" />
        <div>
            <label for="student">Enter Student ID</label>
            <asp:TextBox CssClass="input" ID="student" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="advisor">Enter Advisor ID</label>
            <asp:TextBox CssClass="input" ID="advisor" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button CssClass="button" ID="addSLA" runat="server" OnClick="addStudentAdvisor" Text="Add" />
        </div>
    </form>
</body>
</html>
