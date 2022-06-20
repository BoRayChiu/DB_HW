<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transfer.aspx.cs" Inherits="Web_based_ATM.transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>目標帳戶帳號: </p>
        <asp:TextBox ID="To_userID" runat="server"></asp:TextBox><br />
        <p>金額: </p>
        <asp:TextBox ID="Money" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="Submit" runat="server" Text="確認" OnClick="Submit_Click" /><br /><br />
        <asp:Button ID="Home" runat="server" Text="首頁" OnClick="Home_Click" />
    </form>
</body>
</html>
