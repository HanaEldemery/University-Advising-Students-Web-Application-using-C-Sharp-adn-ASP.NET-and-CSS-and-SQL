<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View Optional.aspx.cs" Inherits="Advising_System.View_Optional" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Current Semester Code:
            <asp:TextBox ID="semCode" runat="server"></asp:TextBox>
            (Semester code format example: &quot;W23&quot;)<br />
            <asp:Button ID="Button2" runat="server" OnClick="viewOptional" Text="View Optional Courses" />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="back" Text="Back" />
        </div>
    </form>
</body>
</html>
