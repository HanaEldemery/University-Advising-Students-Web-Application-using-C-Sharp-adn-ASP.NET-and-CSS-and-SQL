<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoursApproval.aspx.cs" Inherits="Advising_System.HoursApproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter Request ID:<br />
            <asp:TextBox ID="requestId" runat="server"></asp:TextBox>
            <br />
            Enter Current Semester Code:<br />
            <asp:TextBox ID="currSemCode" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="proccess" runat="server" Text="Approve/Reject" OnClick="proccess_Click" />
            <br />
            <br />
            <asp:Button ID="back" runat="server" Text="Go Back" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
