<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student Telephone.aspx.cs" Inherits="Advising_System.Student_Telephone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Phone Number:<asp:TextBox ID="phoneNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="add" Text="Add" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="back" Text="Back" />
        </div>
    </form>
</body>
</html>
