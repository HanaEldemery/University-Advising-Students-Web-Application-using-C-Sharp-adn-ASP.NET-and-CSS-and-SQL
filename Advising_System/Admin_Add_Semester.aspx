<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Add_Semester.aspx.cs" Inherits="Advising_System.Admin_Add_Semester" %>

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
            <label for="startDate">Enter Start Date</label>
            <asp:TextBox TextMode="Date" CssClass="input" ID="startDate" type="date" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="endDate">Enter End Date</label>
            <asp:TextBox TextMode="Date" CssClass="input" ID="endDate" type="date" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="semesterCode">Enter Semester Code</label>
            <asp:TextBox CssClass="input" ID="semesterCode" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button CssClass="button" ID="addSem" runat="server" OnClick="addSemester" Text="Add" />
        </div>
    </form>
</body>
</html>
