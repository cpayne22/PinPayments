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
        private static string _baseUrl;

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

        internal static string GetBaseUrl()
        {
            if (String.IsNullOrEmpty(_baseUrl))
            {
                _baseUrl = ConfigurationManager.AppSettings["URI"];
            }
            return _baseUrl;
        }

        public static void SetBaseUrl(string newBaseUrl)
        {
            _baseUrl = newBaseUrl;
        }
    }
}
