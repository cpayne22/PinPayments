using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PinPayments.Infrastructure
{
    internal static class Urls
    {
        public static string Card
        {
            get { return BaseUrl + "/1/cards"; }
        }

        public static string ChargesSearch
        {
            get { return BaseUrl + "/1/charges/search"; }
        }
        
        public static string Charge
        {
            get { return BaseUrl + "/1/charges"; }
        }

        public static string Charges
        {
            get { return BaseUrl + "/1/charges/"; }
        }

        public static string CustomerAdd
        {
            get { return BaseUrl + "/1/customers"; }
        }

        public static string Customers
        {
            get { return BaseUrl + "/1/customers"; }
        }

        public static string CustomerCharges
        {
            get { return BaseUrl + "/1/customers/{token}/charges"; }
        }

        public static string Refund
        {
            get { return BaseUrl + "/1/charges/{token}/refunds"; }
        }

        private static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["URI"]; }
        }
    }
}
