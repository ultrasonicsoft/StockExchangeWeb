﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="StockExchangeWeb.Portfolio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Portfolios</h3>
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlAllPortfolio" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="LoadPortfolio" runat="server" Text="Load portfolio" OnClick="LoadPortfolio_Click"/>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:GridView ID="gdvPortfolioStocks" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Horizontal">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
