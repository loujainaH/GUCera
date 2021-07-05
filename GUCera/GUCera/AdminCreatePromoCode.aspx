<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminCreatePromoCode.aspx.cs" Inherits="WebApplication1.AdminCreatePromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 457px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Promocode ID</div>
        <asp:TextBox ID="Code" runat="server"></asp:TextBox>
        <br />
        Issue Date (Y/M/D)<br />
        <asp:TextBox ID="IssueDate" runat="server"></asp:TextBox>
        <br />
        Expiry Date(Y/M/D)<br />
        <asp:TextBox ID="ExpDate" runat="server"></asp:TextBox>
        <br />
        Discount<br /> 
        <asp:TextBox ID="Discount" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Add" runat="server" OnClick="Button1_Click" Text="Add Promocode" />
        <br />
        <br />
        <asp:Button ID="home" runat="server" OnClick="Home" Text="Return to home Page" Width="138px" />
    </form>
</body>
</html>
