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
            <img src="https://img.icons8.com/ios-glyphs/30/000000/alarm.png" class="bell">
            <img src="https://img.icons8.com/material/24/000000/user-male-circle.png" class="logo">
        </div>
        <div class="div-class">
            <asp:TextBox ID="searchBox" runat="server" CssClass="tb-class"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" cssClass="btn-class"/>
        </div>
        <div class="div-class">
            <asp:ListBox ID="tablesListBox" runat="server" CssClass="lb-class"></asp:ListBox>
            <asp:ListBox ID="itemsListBox" runat="server" CssClass="lb-class"></asp:ListBox>
        </div>
    </form>
</body>
</html>
