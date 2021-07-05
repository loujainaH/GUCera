

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="GUCera.courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="text-align:center";"height: 358px; width: 518px; position: fixed; top: 15px; left: 10px; font-size: 20px; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-style: normal; font-variant: normal;">
              
                Available Courses:

            </p>
            <p style="text-align:center">

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </p>
              <br />
              
        <br />
            <asp:Button ID="vinst" runat="server" OnClick="Instructors" Text="View instructors" />
        <hr />
            <asp:Button ID="home" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />
        </div>
    </form>
</body>
</html>
