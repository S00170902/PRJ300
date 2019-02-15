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
            <img src="Images/logo.png" style="width: 115px" />
          </div>

        <div style="width: 334px" class="centered-div">
            <table style="margin:auto; border:5px solid white;">
                <tr>
                    <td>
<asp:Label ID="Label1" runat="server" Text="username"></asp:Label>
                    </td>
                     <td>
<asp:TextBox ID="username" runat="server"></asp:TextBox>
                    </td>

                </tr>

                         <tr>
                    <td>
<asp:Label ID="Label2" runat="server" Text="password"></asp:Label>
                    </td>
                     <td>
<asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </td>

                </tr>

                         <tr>
                    <td>

<asp:Label ID="errormessage" runat="server" Text="incorrect user details" Visible="False"></asp:Label>
                             </td>
                     <td>
                         <asp:Button ID="buttonlogin" runat="server" Text="login" OnClick="buttonlogin_Click" />
                             </td>

                </tr>
                         <tr>
                    <td>
                        &nbsp;</td>
                  
                </tr>

            </table>
            
        </div>
    </form>
</body>
</html>