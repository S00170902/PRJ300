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
                <div class="dropdown-content">
                    <asp:ListBox ID="nullsListBox" runat="server" CssClass="lb-class"></asp:ListBox>
                </div>
                <img src="https://img.icons8.com/ios-glyphs/30/000000/alarm.png" class="bell"/>
            </div>
            <div class="settings">
                <img src="https://img.icons8.com/material/30/000000/automatic.png"/>
                <div class="dropdown-content">
                    <asp:Label runat="server">Null Time Allowed</asp:Label>
                    <asp:DropDownList ID="timeAllowedList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="timeAllowedList_SelectedIndexChanged">
                        <asp:ListItem>1 day</asp:ListItem>
                        <asp:ListItem>2 days</asp:ListItem>
                        <asp:ListItem>3 days</asp:ListItem>
                        <asp:ListItem>4 days</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Label runat="server">Null Limit</asp:Label>
                    <asp:DropDownList runat="server" ID="nullLimitList" AutoPostBack="true" OnSelectedIndexChanged="nullLimitList_SelectedIndexChanged">
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                    <br/>
                    <asp:Label runat="server">Colour Scheme</asp:Label>
                    <asp:DropDownList runat="server" ID="coloursList" AutoPostBack="true" OnSelectedIndexChanged="coloursList_SelectedIndexChanged">
                        <asp:ListItem>Red</asp:ListItem>
                        <asp:ListItem>Blue</asp:ListItem>
                    </asp:DropDownList>
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
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>SQL</asp:ListItem>
                <asp:ListItem>Oracle</asp:ListItem>
            </asp:DropDownList>
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
                    <td style="background-color:orange; border:1px solid black;"> <%# DataBinder.Eval(Container.DataItem, "key") %> </td>
                    <td style="border:1px solid black"> <%# DataBinder.Eval(Container.DataItem, "value") %></td>
                </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>
            <div class="bi-btn">
                <asp:Button ID="Button1" runat="server" Text="Power BI" OnClick="Button1_Click" CssClass="btn-class" />
                <br />
                <asp:Button ID="EmailBtn" runat="server" Text="Send Email" OnClick="EmailBtn_Click" CssClass="btn-class" />
            </div>
            
        </div>
    </form>
</body>
</html>