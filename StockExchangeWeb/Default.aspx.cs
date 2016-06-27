using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockExchangeWeb.StockExchangeService;

namespace StockExchangeWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WelcomeMessage.Text = "Welcome " + HttpContext.Current.User.Identity.Name + "!";
                LoadAllStocks();

            }
        }

        private void LoadAllStocks()
        {
            try
            {
                var service = new StockExchangeService.StockExchangeServiceSoapClient();
                var objAuthSoapHeader = WebServiceAuthenticationManager.GetAuthSoapHd();

                var allStocks = service.GetAllStock(objAuthSoapHeader);
                gdvAllStocks.DataSource = allStocks;
                gdvAllStocks.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        protected void Signout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void GetStockPrice_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new StockExchangeService.StockExchangeServiceSoapClient();
                var objAuthSoapHeader = WebServiceAuthenticationManager.GetAuthSoapHd();
                var stockPrice = service.GetStockPrice(objAuthSoapHeader, StockSymbol.Text);
                if (stockPrice == double.MinValue)
                {
                    lblStockPrice.Text = "Invalid stock symbol provided.";
                }
                else
                {
                    lblStockPrice.Text = string.Format("{0} stock is currently trading at price: {1}", StockSymbol.Text,
                        stockPrice.ToString(CultureInfo.InvariantCulture));
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        protected void StockPriceRefreshTimer_Tick1(object sender, EventArgs e)
        {
            LoadAllStocks();
        }
    }
}