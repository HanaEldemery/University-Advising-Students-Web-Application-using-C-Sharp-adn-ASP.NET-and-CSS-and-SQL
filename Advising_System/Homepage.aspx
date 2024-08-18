<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Advising_System.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        To view your students:<br />
        <asp:Button ID="view_all_students" runat="server" OnClick="viewAdvStudents" Text="Your Students" />
        <br />
        To insert graduation plan for a certain student:<br />
        <asp:Button ID="insertPlan" runat="server" OnClick="insert" Text="Insert plan" />
        <br />
        To insert course for specific graduation plan:<br />
        <asp:Button ID="insertCourse" runat="server" OnClick ="insert1" Text="Insert Course" />
        <br />
        To update expected graduation date in a certain graduation plan:<br />
        <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click" />
        <br />
        To delete course from certain graduation plan in certain semester:<br />
        <asp:Button ID="toDelete" runat="server" Text="Delete" OnClick="toDelete_Click" />
        <br />
        To view all students assigned to him/her from a certain major along with their taken courses:<br />
        <asp:Button ID="view" runat="server" Text="View" OnClick="view_Click" />
        <br />
        To view all requests:<br />
        <asp:Button ID="show" runat="server" Text="View" OnClick="show_Click" />
        <br />
        To view all pending requests:<br />
        <asp:Button ID="view1" runat="server" Text="View" OnClick="view1_Click" />
        <br />
        To Approve/Reject Extra Credit Hours requests:<br />
        <asp:Button ID="aprj" runat="server" Text="Approve/Reject" OnClick="aprj_Click" />
        <br />
        To Approve/Reject Extra Courses requests:<br />
        <asp:Button ID="appRej" runat="server" Text="Approve/Reject" OnClick="appRej_Click" />
        <br />
        <br />
        </form>
</body>
</html>
