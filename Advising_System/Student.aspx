<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Advising_System.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800;900&family=Poppins:wght@300;400;500;600;700&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server">
            <h1>What would you like to do?</h1>
            <asp:Button ID="Button1" runat="server" OnClick="telephone" Text="Add telephone number(s)" />
            <asp:Button ID="Button2" runat="server" OnClick="optional" Text="View all optional courses in the current semester" />
            <asp:Button ID="Button3" runat="server" OnClick="available" Text="View all available courses in the current semester" />
            <asp:Button ID="Button4" runat="server" OnClick="required" Text="View the required courses within the current semester" />
            <asp:Button ID="Button5" runat="server" OnClick="missing" Text="View the missing courses" />
            <asp:Button ID="Button6" runat="server" OnClick="sendCrsReq" Text="Send a course request" />
            <asp:Button ID="Button7" runat="server" OnClick="sendCrHrsReq" Text="Send a credit hour request" />
            <asp:Button ID="Button8" runat="server" OnClick="gradPlan" Text="View graduation plan along with assigned courses" />
            <asp:Button ID="Button9" runat="server" OnClick="inst" Text="View the upcoming not paid installment" />
            <asp:Button ID="Button10" runat="server" OnClick="all" Text="View all courses along with their exams details" />
            <asp:Button ID="Button11" runat="server" OnClick="first" Text="Register for first makeup exam" />
            <asp:Button ID="Button12" runat="server" OnClick="second" Text="Register for second makeup exam" />
            <asp:Button ID="Button13" runat="server" OnClick="crslin" Text="View all courses along with their corresponding slots details and instructors" />
            <asp:Button ID="Button14" runat="server" OnClick="slcrsin" Text="View the slots of a certain course that is taught by a certain instructor" />
            <asp:Button ID="Button15" runat="server" OnClick="choose" Text="Choose the instructor for a certain course" /> 
            <asp:Button ID="Button16" runat="server" OnClick="deets" Text="View all details of all courses with their prerequisites" />
            <asp:Button ID="Button17" runat="server" OnClick="logout" Text="Logout" />
    </form>
</body>
</html>
