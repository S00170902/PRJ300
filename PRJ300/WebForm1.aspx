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
            <div class="bell">
                <img src="https://img.icons8.com/ios-glyphs/30/000000/alarm.png" class="bell"/>
                <div class="dropdown-content">
                    <asp:ListBox ID="nullsListBox" runat="server" CssClass="lb-class"></asp:ListBox>
                </div>
            </div>
            <div class="settings">
                <img src="https://img.icons8.com/material/30/000000/automatic.png"/>
                <div class="dropdown-content">
                    <asp:Label ID="timeAllowed" runat="server">Null Time Allowed</asp:Label>
                    <asp:DropDownList ID="timeAllowedList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="timeAllowedList_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="user">
                <img src="https://img.icons8.com/material/24/000000/user-male-circle.png"/>
                <div class="dropdown-content">
                    <asp:Label ID="userWelcome" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:HyperLink ID="signOut" runat="server" NavigateUrl="~/Login.aspx">Sign Out</asp:HyperLink>
                </div>
            </div>
        </div>
        <div class="div-class">
            <asp:TextBox ID="searchBox" runat="server" CssClass="tb-class"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" cssClass="btn-class"/>
            <asp:RadioButton ID="AZRadioButton" GroupName="test" runat="server" AutoPostBack="true" OnCheckedChanged="AZRadioButton_CheckedChanged" />
            <label for="AZRadioButton">A-Z</label>
            <asp:RadioButton ID="ZARadioButton" GroupName="test" runat="server" AutoPostBack="true" OnCheckedChanged="ZARadioButton_CheckedChanged" />
            <label for="ZARadioButton">Z-A</label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>SQL</asp:ListItem>
                <asp:ListItem>Oracle</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="div-class">
            <asp:ListBox ID="tablesListBox" runat="server" CssClass="lb-class"></asp:ListBox>
            <asp:ListBox ID="itemsListBox" runat="server" CssClass="lb-class" AutoPostBack="true" OnSelectedIndexChanged="itemsListBox_SelectedIndexChanged"></asp:ListBox>
        <div class="repeater-div">
            <asp:Repeater ID="details" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                    <td> <%# DataBinder.Eval(Container.DataItem, "key") %> </td>
                    <td> <%# DataBinder.Eval(Container.DataItem, "value") %></td>
                </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        </div>
    </form>
</body>
</html>