<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StockExchangeWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Exchange Dashboard</title>
</head>
<body>
    <h1>Stock Exchange Dashboard</h1>
    <h3>Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server" />
    <form id="Form1" runat="server">
        <asp:Button ID="Submit1" OnClick="Signout_Click"
            Text="Sign Out" runat="server" />
    </form>
</body>
</html>
