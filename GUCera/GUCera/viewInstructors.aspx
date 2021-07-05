<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewInstructors.aspx.cs" Inherits="GUCera.viewInstructors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="t" runat="server" style="visibility:hidden;">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> 



           

                <br />

                </div>       
        
        <div id="first" runat="server">
            <hr />
            <br />
            <br />
            Course ID:&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<asp:TextBox ID="cid" runat="server" Width="138px" style="margin-left: 14px"></asp:TextBox>
            

            <br />&nbsp;&nbsp;&nbsp;<br />
          
            <br />
            <br />
&nbsp;<asp:Button ID="instr" runat="server" OnClick="Instructors" Text="View Instructors" Width="170px" />
        <br />
        <br />
        <hr />
          
        </div>

        <div>
              <asp:Button ID="home" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />
        </div>
         

    </form>
</body>
</html>

