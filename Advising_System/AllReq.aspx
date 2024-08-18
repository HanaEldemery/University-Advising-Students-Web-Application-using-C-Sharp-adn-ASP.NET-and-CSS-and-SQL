<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllReq.aspx.cs" Inherits="Advising_System.AllReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="requests" runat="server" AutoGenerateColumns="true"></asp:GridView>
           
            <br />
            <br />
            <asp:Button ID="Back" runat="server" Text="Go Back" OnClick="Back_Click" />
        </div>
    </form>
</body>
</html>
