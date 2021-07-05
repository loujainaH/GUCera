<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAcceptReqCourses.aspx.cs" Inherits="WebApplication1.AdminAcceptReqCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Enter course code<br />
            <asp:TextBox ID="Code" runat="server"></asp:TextBox>
            <br />
        </div>
        <asp:Button ID="accept" runat="server" OnClick="Accept" Text="Accept Course" Width="113px" />
        <br />
        <br />
        <asp:Button ID="home" runat="server" OnClick="Home" Text="Return to home Page" Width="138px" />

    </form>
</body>
</html>
