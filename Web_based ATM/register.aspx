<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Web_based_ATM.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>請輸入欲使用帳號名稱(40字以內英、數字、特殊符號皆可): </p>
        <asp:TextBox ID="ID" runat="server"></asp:TextBox>
        <p>請輸入真實姓名(EX: 陳小華): </p>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <p>請輸入欲使用密碼(45字以內英、數字、特殊符號皆可 不可使用空白字元): </p>
        <asp:TextBox ID="pwd" TextMode="Password" runat="server"></asp:TextBox>
        <p>請確認密碼: </p>
        <asp:TextBox ID="check_pwd" TextMode="Password" runat="server"></asp:TextBox>
        <p>請勾選性別: </p>
        <asp:DropDownList ID="gender" runat="server">
            <asp:ListItem Value="m">男</asp:ListItem>
            <asp:ListItem Value="f">女</asp:ListItem>
            <asp:ListItem Value="n">不透露</asp:ListItem>
        </asp:DropDownList><br /><br />
        <asp:Button ID="Submit" runat="server" Text="確認" OnClick="Check_Click" />
    </form>
</body>
</html>
