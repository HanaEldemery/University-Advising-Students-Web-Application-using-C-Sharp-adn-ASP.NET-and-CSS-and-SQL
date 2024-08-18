<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Issues_Installments.aspx.cs" Inherits="Advising_System.Admin_Issues_Installments" %>

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
    <form id="form4" runat="server">
        <asp:Button ID="home" CssClass="button" runat="server" OnClick="backHomeFn" Text="Home" />
        <div>
            <label for="installmentsIssued">Enter Payment ID</label>
            <asp:TextBox CssClass="input" ID="installmentsIssued" type="text" runat="server"></asp:TextBox>
            <asp:Button CssClass="button" ID="issueIn" runat="server" OnClick="IssueInstallment" Text="Issue" />
        </div>
    </form>
</body>
</html>
