<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PRJ300.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
            <asp:Button ID="Button1" runat="server" OnClick="onClick" Text="Filter nulls" class="btn-class"/>
               <div class="div-class">
           <asp:Image ID="Image1" runat="server" CssClass="logo" ImageUrl="~/Images/logo.png" align="right"/>
       </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DummyTableID"  BackColor="White" HorizontalAlign="Center" CssClass="gv-class">
            <Columns>
                <asp:BoundField DataField="DummyTableID" HeaderText="DummyTableID" InsertVisible="False" ReadOnly="True" SortExpression="DummyTableID" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            </Columns>
        </asp:GridView>
       
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductID" BackColor="White" HorizontalAlign="Center" CssClass="gv-class">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
