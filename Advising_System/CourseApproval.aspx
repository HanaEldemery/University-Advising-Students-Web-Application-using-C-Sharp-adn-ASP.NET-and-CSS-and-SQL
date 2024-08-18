<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseApproval.aspx.cs" Inherits="Advising_System.CourseApproval" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter RequestID:<br />
            <asp:TextBox ID="reqId" runat="server"></asp:TextBox>
            <br />
            Enter Current Semester Code:<br />
            <asp:TextBox ID="semCode" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ApprovalReq" runat="server" Text="Approval/Rejection" OnClick="ApprovalReq_Click" />
            <br />
            <asp:Button ID="back" runat="server" Text="Go back" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
