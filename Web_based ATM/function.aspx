<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="function.aspx.cs" Inherits="Web_based_ATM.function" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <body>
        <form id="form1" runat="server">
             <asp:Table id="Table1" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
                <asp:TableRow><asp:TableCell><asp:HyperLink ID="HyperLink1" NavigateUrl="~/account_information.aspx" runat="server">查看帳戶資訊</asp:HyperLink></asp:TableCell>
                <asp:TableCell><asp:HyperLink ID="HyperLink_Desposit" NavigateUrl="~/desposite.aspx" runat="server">存款</asp:HyperLink></asp:TableCell></asp:TableRow>
                <asp:TableRow><asp:TableCell><asp:HyperLink ID="HyperLink_Withdaraw" NavigateUrl="~/withdraw.aspx" runat="server">提款</asp:HyperLink></asp:TableCell>
                <asp:TableCell><asp:HyperLink ID="HyperLink_Transfer" NavigateUrl="~/transfer.aspx" runat="server">匯款</asp:HyperLink></asp:TableCell></asp:TableRow>
            </asp:Table>
            <asp:Button ID="Logout" runat="server" Text="登出" OnClick="Logout_Click" />
        </form>
    </body>
</html>
