<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCreditCard.aspx.cs" Inherits="GUCera.addCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
              <div id="anotherOne" runat="server" style="visibility:hidden;">
                  <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                  Credit Card Added Successfully!&nbsp;
                    <br />
                    Add another one?&nbsp;&nbsp;&nbsp;<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="yes" runat="server" OnClick="Yes" Text="YES!!!" Width="60px" />  
                    <hr />
            <asp:Button ID="home2" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />

                </div>    
           <div id="firstOne" runat="server" style="height: 358px; width: 518px; position: fixed; top: 15px; left: 10px; font-size: 20px; font-family: Arial, Helvetica, sans-serif; font-weight: bold; font-style: normal; font-variant: normal;">
            &nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <hr style="margin-top: 0px" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Add Your Credit Card Details<br />
            <br />
            <hr />
               <br />
            <br />

           Number&nbsp;
            <asp:TextBox ID="number" runat="server" style="margin-left: 104px" MaxLength="15"></asp:TextBox>
            <br />
            <br />
            Card
            Holder Name&nbsp;&nbsp; 
            <asp:TextBox ID="chname" runat="server" MaxLength="16"></asp:TextBox>
            <br />
            <br />
             Expiry Date&nbsp;&nbsp;&nbsp; 
            <asp:TextBox  ID="exdate" runat="server" style="margin-left: 58px" OnClick="text1" ForeColor="#999999">YYYY/MM/DD</asp:TextBox>
            <br />
            <br />
            CVV&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; 
            <asp:TextBox ID="cvv" runat="server" style="margin-left: 80px" MaxLength="3"></asp:TextBox>
            <br />
            <br />
               <br />
            <br />
            <asp:Button ID="Credit" runat="server" OnClick="add" Text="Add Card" Width="244px" 
               style="font-weight: bold;background-color: black; 
                      color:white; font-size:30px; box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);"
                Height="37px" Font-Size="Larger" />
            <br />
              
        <br />
        <hr />
            <asp:Button ID="home" runat="server" OnClick="Home" Text="Return To Home Page" Width="170px" />
        
        </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
              <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    </form>
    </body>
</html>
