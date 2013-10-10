using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PinPayments
{
    public static class PinPaymentsConfig
    {
        private static string _apiKey;

        internal static string GetApiKey()
        {
            if (String.IsNullOrEmpty(_apiKey))
            {
               // _apiKey = ConfigurationManager.AppSettings["Publish_API"];
            }
            if (String.IsNullOrEmpty(_apiKey))
            {
                _apiKey = ConfigurationManager.AppSettings["Secret_API"];
            }

            return _apiKey;
        }

        public static void SetApiKey(string newApiKey)
        {
            _apiKey = newApiKey;
        }
    }
}
