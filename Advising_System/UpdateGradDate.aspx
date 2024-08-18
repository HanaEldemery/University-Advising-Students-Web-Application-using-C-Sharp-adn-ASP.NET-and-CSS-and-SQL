<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateGradDate.aspx.cs" Inherits="Advising_System.UpdateGradDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Expected Grad Date:<br />
            <asp:TextBox ID="gradDate" runat="server"></asp:TextBox>
            <br />
            Enter Student ID:<br />
            <asp:TextBox ID="studId" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="updateDate" runat="server" Text="Update" OnClick="updateDate_Click" />
            <br />
            <br />
            <asp:Button ID="goback" runat="server" Text="Go Back" OnClick="goback_Click" />
        </div>
    </form>
</body>
</html>
