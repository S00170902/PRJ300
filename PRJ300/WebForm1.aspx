<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PRJ300.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DummyTableID" DataSourceID="SqlDataSource1" BackColor="White">
            <Columns>
                <asp:BoundField DataField="DummyTableID" HeaderText="DummyTableID" InsertVisible="False" ReadOnly="True" SortExpression="DummyTableID" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:S00171672ConnectionString %>" SelectCommand="SELECT DummyTableID, ProductID, Name, price FROM DummyTable WHERE (Name IS NULL) OR (price IS NULL)"></asp:SqlDataSource>
    </form>
</body>
</html>
