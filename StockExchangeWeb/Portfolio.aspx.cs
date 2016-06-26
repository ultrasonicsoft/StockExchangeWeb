using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockExchangeWeb.StockExchangeService;

namespace StockExchangeWeb
{
    public partial class Portfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllPortfolios();
            }
        }

        private void LoadAllPortfolios()
        {
            var userName = HttpContext.Current.User.Identity.Name;
            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            var objAuthSoapHeader = new AuthSoapHd
            {
                strUserName = "TestUser",
                strPassword = "TestPassword"
            };
            var allPortfolio = service.GetAllPortfolios(objAuthSoapHeader, userName);
            ddlAllPortfolio.DataTextField = "Name";
            ddlAllPortfolio.DataValueField = "Id";
            ddlAllPortfolio.DataSource = allPortfolio;
            ddlAllPortfolio.DataBind();
        }

        protected void LoadPortfolio_Click(object sender, EventArgs e)
        {
            var selectedPortfolio = int.Parse(ddlAllPortfolio.SelectedValue);
            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            var objAuthSoapHeader = new AuthSoapHd
            {
                strUserName = "TestUser",
                strPassword = "TestPassword"
            };
            var portfolioDetails = service.GetPortfolioDetails(objAuthSoapHeader, selectedPortfolio);
            gdvPortfolioStocks.DataSource = portfolioDetails;
            gdvPortfolioStocks.DataBind();
        }
    }
}