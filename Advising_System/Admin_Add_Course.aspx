<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Add_Course.aspx.cs" Inherits="Advising_System.Admin_Add_Course" %>

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
            <label for="major">Enter Major</label>
            <asp:TextBox CssClass="input" ID="major" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="semester">Enter Semester ID</label>
            <asp:TextBox CssClass="input" ID="semester" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="creditHours">Enter Credit Hours</label>
            <asp:TextBox CssClass="input" ID="creditHours" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="name">Enter Course Name</label>
            <asp:TextBox CssClass="input" ID="name" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="isOffered">Is Offered</label>
            <asp:CheckBox CssClass="input" ID="isOffered" runat="server"></asp:CheckBox>
        </div>
        <div>
            <asp:Button CssClass="button" ID="addSem" runat="server" OnClick="addSemester" Text="Add" />
        </div>
    </form>
</body>
</html>
