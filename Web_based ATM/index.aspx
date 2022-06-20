<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web_based_ATM.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Web_Based ATM</title>
</head>
    <body>
        <form runat="server">
            <p>帳號: </p>
            <p><asp:TextBox ID="UserID" runat="server"></asp:TextBox ></p>
            <p>密碼: </p>
            <p><asp:TextBox ID="Userpwd" TextMode="Password" runat="server"></asp:TextBox></p>
            <p><asp:HyperLink ID="HyperLink_register" NavigateUrl="~/register.aspx" Text="註冊新帳號" Target="_blank" runat="server"></asp:HyperLink></p>
            <p><asp:Button ID="LogIn" runat="server" Text="登入" OnClick="Button1_Click" /></p>
        </form>
    </body>
</html>
