<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewPromocode.aspx.cs" Inherits="GUCera.viewPromocode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">Your Promocodes:<br />
        </div>
        <div>
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
               
              <br />
              
        <br />
        <hr />
            <asp:Button ID="home" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />
        </div>
    </form>
</body>
</html>
