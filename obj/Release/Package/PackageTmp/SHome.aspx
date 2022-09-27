<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SHome.aspx.cs" Inherits="HMSAPP_web.SHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 600px">
            Doctor Login Form</div>
        <asp:Label ID="Label3" runat="server" Text="Username:-"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="DocName" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Password:-"></asp:Label>
            <asp:TextBox ID="DocPass" runat="server" OnTextChanged="TextBox2_TextChanged" style="margin-left: 34px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 157px" Text="Login" />
    </form>
</body>
</html>
