<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradPlan.aspx.cs" Inherits="Advising_System.GradPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Enter Semester Code:<br />
            <asp:TextBox ID="semCode" runat="server"></asp:TextBox>
            <br />
            Enter expected Graduation Date:<br />
            <asp:TextBox ID="gradDate" runat="server"></asp:TextBox>
            <br />
            Enter Semester Credit Hours:<br />
            <asp:TextBox ID="sem_credHours" runat="server"></asp:TextBox>
            <br />
            Enter Student Id:<br />
            <asp:TextBox ID="studentId" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="insertData" runat="server" OnClick ="insert" Text="Insert" />
            <br />
            <br />
            <asp:Button ID="Back" runat="server" Text="Go Back" OnClick="Back_Click" />
        </div>
    </form>
</body>
</html>
