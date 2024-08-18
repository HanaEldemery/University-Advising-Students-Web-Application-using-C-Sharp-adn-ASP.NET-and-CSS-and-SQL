<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View Required.aspx.cs" Inherits="Advising_System.View_Required" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Current Semester Code:<asp:TextBox ID="semCode" runat="server"></asp:TextBox>
            (Semester code format example: &quot;W23&quot;)<br />
            <asp:Button ID="Button1" runat="server" OnClick="viewRequired" Text="View Required Courses" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="back" Text="Back" />
        </div>
    </form>
</body>
</html>
