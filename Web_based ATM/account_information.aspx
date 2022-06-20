<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account_information.aspx.cs" Inherits="Web_based_ATM.account_information" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID ="Table1" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
            <asp:TableRow><asp:TableCell>帳號</asp:TableCell><asp:TableCell ID ="UserID"></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell>名字</asp:TableCell><asp:TableCell ID ="UserName"></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell>密碼</asp:TableCell><asp:TableCell ID ="UserPwd"></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell>性別</asp:TableCell><asp:TableCell ID ="UserGender"></asp:TableCell></asp:TableRow>
            <asp:TableRow><asp:TableCell>餘額</asp:TableCell><asp:TableCell ID ="Balance"></asp:TableCell></asp:TableRow>
        </asp:Table>
        <p>近期帳戶異動紀錄(前五筆)</p>
        <asp:GridView ID="GridView" CellPadding="10" GridLines="Both" HorizontalAlign="Center" runat="server"></asp:GridView><br />
        <asp:Button ID="Home" runat="server" Text="首頁" OnClick="Home_Click" />
    </form>
</body>
</html>
