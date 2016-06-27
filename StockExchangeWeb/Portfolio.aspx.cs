using System;
using System.Collections.Generic;
using System.Configuration;
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
            try
            {
                var userName = HttpContext.Current.User.Identity.Name;
                var service = new StockExchangeService.StockExchangeServiceSoapClient();
                var objAuthSoapHeader = WebServiceAuthenticationManager.GetAuthSoapHd();
                var allPortfolio = service.GetAllPortfolios(objAuthSoapHeader, userName);
                ddlAllPortfolio.DataTextField = "Name";
                ddlAllPortfolio.DataValueField = "Id";
                ddlAllPortfolio.DataSource = allPortfolio;
                ddlAllPortfolio.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        protected void LoadPortfolio_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedPortfolio = int.Parse(ddlAllPortfolio.SelectedValue);
                var service = new StockExchangeService.StockExchangeServiceSoapClient();
                var objAuthSoapHeader = WebServiceAuthenticationManager.GetAuthSoapHd();
                var portfolioDetails = service.GetPortfolioDetails(objAuthSoapHeader, selectedPortfolio);
                gdvPortfolioStocks.DataSource = portfolioDetails;
                gdvPortfolioStocks.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

    }
}