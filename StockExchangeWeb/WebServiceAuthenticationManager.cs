using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using StockExchangeWeb.StockExchangeService;

namespace StockExchangeWeb
{
    public class WebServiceAuthenticationManager
    {
        public static AuthSoapHd GetAuthSoapHd()
        {
            var objAuthSoapHeader = new AuthSoapHd
            {
                strUserName = ConfigurationSettings.AppSettings["webServiceUserName"],
                strPassword = ConfigurationSettings.AppSettings["webServicePassword"]
            };
            return objAuthSoapHeader;
        }
    }
}