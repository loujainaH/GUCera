﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentListCertificates.aspx.cs" Inherits="GUCera.studentListCertificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 430px">
             Please enter the ID of the course:<br />
            <asp:TextBox ID="course" runat="server" Width="129px"></asp:TextBox>
            <asp:Button ID="Certificate" runat="server" OnClick="certificate" Text="confirm" Width="70px" />
            <br />
             <hr />
             <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
             <br />
            <asp:Button ID="home" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />

        </div>
    </form>
</body>
</html>
