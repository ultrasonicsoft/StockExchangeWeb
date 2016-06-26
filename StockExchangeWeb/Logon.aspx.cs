using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockExchangeWeb
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logon_Click(object sender, EventArgs e)
        {
            StockExchangeService.StockExchangeServiceSoapClient service = new StockExchangeService.StockExchangeServiceSoapClient();
            var isAuthenticated = service.Logon(UserEmail.Text, UserPass.Text);
            if (isAuthenticated)
            {
                FormsAuthentication.RedirectFromLoginPage
                   (UserEmail.Text, Persist.Checked);
            }
            else
            {
                Msg.Text = "Invalid credentials. Please try again.";
            }
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            var userName = CreateUserWizard1.UserName;
            var password = CreateUserWizard1.Password;
            var email = CreateUserWizard1.Email;
            StockExchangeService.User newUser = new StockExchangeService.User
            {
                Email = email,
                Password = password,
                UserName = userName
            };

            StockExchangeService.StockExchangeServiceSoapClient service = new StockExchangeService.StockExchangeServiceSoapClient();
            service.SignUp(newUser);
        }
    }
}