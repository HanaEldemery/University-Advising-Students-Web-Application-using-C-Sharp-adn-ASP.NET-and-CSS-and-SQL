<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Add_MakeUp.aspx.cs" Inherits="Advising_System.Admin_Add_MakeUp" %>

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
            <label for="type">Enter Type</label>
            <asp:TextBox CssClass="input" ID="type" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="date">Enter Date</label>
            <asp:TextBox TextMode="Date" CssClass="input" ID="date" type="date" runat="server"></asp:TextBox>
        </div>
        <div>
            <label for="courseId">Enter Course ID</label>
            <asp:TextBox CssClass="input" ID="courseId" type="text" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button CssClass="button" ID="addMU" runat="server" OnClick="addMakeUp" Text="Add" />
        </div>
    </form>
</body>
</html>
