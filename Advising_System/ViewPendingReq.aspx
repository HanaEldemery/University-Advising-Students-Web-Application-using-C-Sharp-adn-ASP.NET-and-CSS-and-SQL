<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewPendingReq.aspx.cs" Inherits="Advising_System.ViewPendingReq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
        
              <asp:GridView ID="viewPenReq" runat="server"  AutoGenerateColumns="True"></asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Go Back" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
