using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockExchangeWeb.StockExchangeService;

namespace StockExchangeWeb
{
    public partial class CreatePortfolio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllStocks();
            }
        }

        private void LoadAllStocks()
        {
            try
            {
                var service = new StockExchangeService.StockExchangeServiceSoapClient();
                var objAuthSoapHeader = new AuthSoapHd
                {
                    strUserName = "TestUser",
                    strPassword = "TestPassword"
                };
                var allStocks = service.GetAllStock(objAuthSoapHeader).ToList();
                ddlAllStocks.DataTextField = "Code";
                ddlAllStocks.DataValueField = "Code";
                ddlAllStocks.DataSource = allStocks;
                ddlAllStocks.DataBind();
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string item = e.Row.Cells[0].Text;
                    foreach (Button button in e.Row.Cells[3].Controls.OfType<Button>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            try
            {
                var service = new StockExchangeService.StockExchangeServiceSoapClient();

                var objAuthSoapHeader = new AuthSoapHd
                {
                    strUserName = "TestUser",
                    strPassword = "TestPassword"
                };

                var allStocks = service.GetAllStock(objAuthSoapHeader).ToList();

                var selectedStockCode = ddlAllStocks.SelectedItem;
                var selectedStock = allStocks.FirstOrDefault(x => x.Code == selectedStockCode.ToString());
                if (selectedStock == null)
                {
                    return;
                }

                var portfolioStocks = Session["portfolioStocks"] as List<Stock> ?? new List<Stock>();
                if (portfolioStocks.FirstOrDefault(x => x.Code == selectedStock.Code) != null)
                {
                    return;
                }
                portfolioStocks.Add(selectedStock);

                gdvPortfolioStocks.DataSource = portfolioStocks;
                gdvPortfolioStocks.DataBind();

                Session["portfolioStocks"] = portfolioStocks;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var index = Convert.ToInt32(e.RowIndex);
                var portfolioStocks = Session["portfolioStocks"] as List<Stock> ?? new List<Stock>();
                portfolioStocks.RemoveAt(index);
                gdvPortfolioStocks.DataSource = portfolioStocks;
                gdvPortfolioStocks.DataBind();
                Session["portfolioStocks"] = portfolioStocks;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var portfolioStocks = Session["portfolioStocks"] as List<Stock>;
                if (portfolioStocks == null)
                {
                    return;
                }

                var newPortfolio = new StockExchangeService.Portfolio
                {
                    Name = PortfolioName.Text,
                    UserId = HttpContext.Current.User.Identity.Name
                };
                var stockIds = new List<int>();

                foreach (var portfolioStock in portfolioStocks)
                {
                    stockIds.Add(portfolioStock.Id);
                }
                newPortfolio.StockIds = stockIds.ToArray();
                var service = new StockExchangeService.StockExchangeServiceSoapClient();
                var objAuthSoapHeader = new AuthSoapHd
                {
                    strUserName = "TestUser",
                    strPassword = "TestPassword"
                };
                service.CreatePortfolio(objAuthSoapHeader, newPortfolio);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}