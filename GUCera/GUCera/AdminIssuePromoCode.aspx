<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIssuePromoCode.aspx.cs" Inherits="GUCera.AdminIssuePromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Enter student ID</p>
        <p>
            <asp:TextBox ID="ID" runat="server"></asp:TextBox>
        </p>
        <p>
            Enter PromoCode
        </p>
        <p>
            <asp:TextBox ID="Code" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </p>
        <asp:Button ID="Issue" runat="server" OnClick="Button1_Click" Text="IssuePromoCode" />
        <br />
        <br />
        <asp:Button ID="home" runat="server" OnClick="Home" Text="Return to home page" Width="149px" />
    </form>
</body>
</html>
