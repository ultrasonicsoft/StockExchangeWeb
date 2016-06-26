using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            var allStocks = service.GetAllStock();
            gdvAllStocks.DataSource = allStocks;
            gdvAllStocks.DataBind();
        }

        protected void Signout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void GetStockPrice_Click(object sender, EventArgs e)
        {
            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            var stockPrice = service.GetStockPrice(StockSymbol.Text);
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

        protected void StockPriceRefreshTimer_Tick1(object sender, EventArgs e)
        {
            LoadAllStocks();
        }
    }
}