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
            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            var allStocks = service.GetAllStock().ToList();
            ddlAllStocks.DataTextField = "Code";
            ddlAllStocks.DataValueField = "Code";
            ddlAllStocks.DataSource = allStocks;
            ddlAllStocks.DataBind();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            var allStocks = service.GetAllStock().ToList();

            var selectedStockCode = ddlAllStocks.SelectedItem;
            var selectedStock = allStocks.FirstOrDefault(x => x.Code == selectedStockCode.ToString());
            if (selectedStock == null)
            {
                return;
            }

            var portfolioStocks = Session["portfolioStocks"] as List<Stock> ?? new List<Stock>();
            if (portfolioStocks.FirstOrDefault(x=>x.Code == selectedStock.Code) != null)
            {
                return;
            }
            portfolioStocks.Add(selectedStock);

            gdvPortfolioStocks.DataSource = portfolioStocks;
            gdvPortfolioStocks.DataBind();

            Session["portfolioStocks"] = portfolioStocks;
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            var portfolioStocks = Session["portfolioStocks"] as List<Stock> ?? new List<Stock>();
            portfolioStocks.RemoveAt(index);
            gdvPortfolioStocks.DataSource = portfolioStocks;
            gdvPortfolioStocks.DataBind();
            Session["portfolioStocks"] = portfolioStocks;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            var portfolioStocks = Session["portfolioStocks"] as List<Stock>;
            if (portfolioStocks == null)
            {
                return;
            }

            StockExchangeService.Portfolio newPortfolio = new StockExchangeService.Portfolio();
            newPortfolio.Name = PortfolioName.Text;
            newPortfolio.UserId = HttpContext.Current.User.Identity.Name;
            newPortfolio.StockIds = new ArrayOfInt();
            foreach (var portfolioStock in portfolioStocks)
            {
                newPortfolio.StockIds.Add(portfolioStock.Id);
            }

            var service = new StockExchangeService.StockExchangeServiceSoapClient();
            service.CreatePortfolio(newPortfolio);
        }
    }
}