<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Advising_System.Main" %>

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
                Who are you?
            </h1>
            <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="student" Text="Student" />
            <br />
            <asp:Button ID="Button2" CssClass="button" runat="server" Text="Advisor" OnClick="Button2_Click" />
            <br />
            <asp:Button ID="Button3" runat="server" CssClass="button" Text="Admin" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
