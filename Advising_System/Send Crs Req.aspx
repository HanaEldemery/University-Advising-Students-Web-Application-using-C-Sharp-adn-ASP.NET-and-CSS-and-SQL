<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send Crs Req.aspx.cs" Inherits="Advising_System.Send_Crs_Req" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Course ID:<asp:TextBox ID="courseId" runat="server"></asp:TextBox>
            <br />
            Type:<asp:TextBox ID="type" runat="server"></asp:TextBox>
            (Please write a sentence that contains the word &quot;Course&quot;)<br />
            Comment:<asp:TextBox ID="comment" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="send" Text="Send" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="back" Text="Back" />
        </div>
    </form>
</body>
</html>
