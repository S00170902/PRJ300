<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PRJ300.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
               <div class="div-class">
           <asp:Image ID="Image1" runat="server" CssClass="logo" ImageUrl="~/Images/logo.png" align="right"/>
       </div>
            <asp:ListBox ID="ListBox1" runat="server" Height="264px" Width="227px"></asp:ListBox>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button_Click"/>
    </form>
</body>
</html>
