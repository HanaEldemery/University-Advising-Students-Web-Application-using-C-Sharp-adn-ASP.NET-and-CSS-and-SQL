<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YourStudents.aspx.cs" Inherits="Advising_System.YourStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <asp:GridView ID="viewStud" runat="server"  AutoGenerateColumns="True"></asp:GridView>
            <br />
            <asp:Button ID ="back" runat="server" Text="Go Back" OnClick="back_Click" />
        </div>
    </form>
</body>
</html>
