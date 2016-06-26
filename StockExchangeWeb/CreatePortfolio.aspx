<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePortfolio.aspx.cs" Inherits="StockExchangeWeb.CreatePortfolio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Create New Portfolio</h3>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Portfolio Name: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="PortfolioName" runat="server" placeholder="Enter new portfolio name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="PortfolioName" runat="server" ErrorMessage="Portfolio Name required"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="Save" runat="server" Text="Save Portfoio" OnClick="Save_Click" />

                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlAllStocks" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnAddStock" CausesValidation="False" runat="server" Text="Add stock to portfolio" OnClick="btnAddStock_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gdvPortfolioStocks" AutoGenerateColumns="False" OnRowDataBound = "OnRowDataBound" OnRowDeleting="OnRowDeleting" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="Code" HeaderText="Symbol" />
                            <asp:BoundField DataField="Name" HeaderText="Stock Name" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />

                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
