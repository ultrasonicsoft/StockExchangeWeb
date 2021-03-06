﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="StockExchangeWeb.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Stock Exchange System</h3>
        <h4>Login</h4>
        <table>
            <tr>
                <td>E-mail address:</td>
                <td>
                    <asp:TextBox ID="UserEmail" runat="server" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="UserEmail"
                        Display="Dynamic"
                        ErrorMessage="Cannot be empty."
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password:</td>
                <td>
                    <asp:TextBox ID="UserPass" TextMode="Password"
                        runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        ControlToValidate="UserPass"
                        ErrorMessage="Cannot be empty."
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>Remember me?</td>
                <td>
                    <asp:CheckBox ID="Persist" runat="server" /></td>
            </tr>
        </table>
        <asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log On"
            runat="server" />
        <p>
            <asp:Label ID="Msg" ForeColor="red" runat="server"  />
        </p>
        
        <h4>Register</h4>
        
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </form>
</body>
</html>
