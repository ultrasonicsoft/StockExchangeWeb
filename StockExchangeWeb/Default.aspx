<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StockExchangeWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Exchange Dashboard</title>

    <style>
        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #333;
        }

        li {
            float: left;
        }

            li a {
                display: block;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

                li a:hover:not(.active) {
                    background-color: #111;
                }

        .active {
            background-color: #4CAF50;
        }

        .loggedInUser {
            background-color: cadetblue;
        }
    </style>

</head>
<body>
    <ul>
        <li><a href="Default.aspx">Market</a></li>
        <li><a href="Portfolio.aspx">Manage Portfolios</a></li>
        <li><a href="CreatePortfolio.aspx">Create Portfolios</a></li>
        <li style="float: right"><a class="active" runat="server" href="#" onserverclick="Signout_Click">Sign Out</a></li>
        <li style="float: right">
            <asp:HyperLink class="loggedInUser" ID="WelcomeMessage" runat="server"></asp:HyperLink>
        </li>
    </ul>
    <h1>Stock Exchange Dashboard</h1>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Timer ID="StockPriceRefreshTimer" runat="server" Interval="5000" OnTick="StockPriceRefreshTimer_Tick1"></asp:Timer>

        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <h3>Check Stock Price</h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="StockSymbol" runat="server" PlaceHolder="Enter stock symbol"></asp:TextBox>
                                <asp:Button ID="GetStockPrice" runat="server" Text="Get Price" OnClick="GetStockPrice_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStockPrice" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <h3>All Stocks</h3>
                </td>
            </tr>
           
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gdvAllStocks" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>

</body>
</html>
