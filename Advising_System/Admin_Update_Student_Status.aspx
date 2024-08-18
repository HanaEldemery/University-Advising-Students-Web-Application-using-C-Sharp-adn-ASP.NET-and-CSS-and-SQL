<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Update_Student_Status.aspx.cs" Inherits="Advising_System.Admin_Update_Student_Status" %>

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
    <form id="form4" runat="server">
        <asp:Button ID="home" CssClass="button" runat="server" OnClick="backHomeFn" Text="Home" />
        <div>
            <label for="studentUpdated">Enter Student ID</label>
            <asp:TextBox CssClass="input" ID="studentUpdated" type="text" runat="server"></asp:TextBox>
            <asp:Button CssClass="button" ID="updateS" runat="server" OnClick="updateStudentStatus" Text="Update" />
        </div>
    </form>
</body>
</html>
