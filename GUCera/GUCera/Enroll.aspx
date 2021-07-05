<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enroll.aspx.cs" Inherits="GUCera.Enroll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="enrollAgain" runat="server" style="visibility:hidden;">
                    Enrolled successfully !&nbsp;
                    <br />
                    Want to enroll in another course?&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="yes" runat="server" OnClick="Yes" Text="YES!!!" Width="60px" />  
                    <hr />
            <asp:Button ID="home2" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />

                </div>       
        
        <div id="firstCourse" runat="server">
            <hr />
            <br />
            <br />
            Course ID:&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<asp:TextBox ID="cid" runat="server" Width="138px" style="margin-left: 14px"></asp:TextBox>
            <br />
            Instructor ID:&nbsp;&nbsp;&nbsp;&nbsp;   <asp:TextBox ID="instr" runat="server" Width="141px"></asp:TextBox>
            &nbsp;<br />

            <br />&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:Button ID="enr" runat="server" OnClick="enrollcourse" Text="Enroll" Width="170px" />
        <br />
        <br />
        <hr />
            <asp:Button ID="home" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />
        </div>
         

    </form>
</body>
</html>
