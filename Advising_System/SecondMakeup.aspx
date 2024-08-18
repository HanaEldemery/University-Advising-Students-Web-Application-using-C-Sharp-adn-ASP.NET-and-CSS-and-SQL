<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondMakeup.aspx.cs" Inherits="Advising_System.SecondMakeup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Course ID&nbsp;
            <asp:TextBox ID="TextBox2" type="number" runat="server"></asp:TextBox>
            <br />
            Semester Code&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register For Second Makeup" />
        &nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" />
        </div>
    </form>
</body>
</html>
