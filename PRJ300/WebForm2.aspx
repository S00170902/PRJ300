<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PRJ300.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="div-class">
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
        </div>
        <div class="div-class">
            <asp:ListBox ID="tablesListBox" runat="server" CssClass="lb-class" AutoPostBack="true" OnSelectedIndexChanged="tablesListBox_SelectedIndexChanged"></asp:ListBox>
            <asp:ListBox ID="itemsListBox" runat="server" CssClass="lb-class" AutoPostBack="true" OnSelectedIndexChanged="itemsListBox_SelectedIndexChanged"></asp:ListBox>
        <div class="repeater-div">
            <asp:Repeater ID="details" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
              <tr style="border:1px solid black">
                    <td style="background-color:#ff5d55; border:1px solid black;"> <%# DataBinder.Eval(Container.DataItem, "key") %> </td>
                    <td style="border:1px solid black"> <%# DataBinder.Eval(Container.DataItem, "value") %></td>
                  </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>
                        <div class="bi-btn">
                <asp:Button ID="Button1" runat="server" Text="Power BI" OnClick="Button1_Click" />
            </div>
        </div>
    </form>
</body>
</html>