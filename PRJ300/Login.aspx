<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PRJ300.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="centered-div">
            <img src="Images/logo.png" />
            <input id="userName" type="text" placeholder="Username" class="input"/>
            <input id="password" type="text" placeholder="Password" class="input"/>
            <asp:Button ID="loginButton" runat="server" Text="Login" CssClass="login-btn" />
        </div>
    </form>
</body>
</html>