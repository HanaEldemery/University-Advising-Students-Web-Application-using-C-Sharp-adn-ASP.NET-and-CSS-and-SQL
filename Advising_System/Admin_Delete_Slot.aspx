<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Delete_Slot.aspx.cs" Inherits="Advising_System.Admin_Delete_Slot" %>

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
            <label for="slotDeleted">Enter Current Semester ID</label>
            <asp:TextBox CssClass="input" ID="slotDeleted" type="text" runat="server"></asp:TextBox>
            <asp:Button CssClass="button" ID="deleteS" runat="server" OnClick="deleteSlot" Text="Delete" />
        </div>
    </form>
</body>
</html>
