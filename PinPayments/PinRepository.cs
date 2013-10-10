using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;
using System.IO;
using PinPayments.Models;

namespace PinPayments
{
    /*
    public class PinRepository
    {
        string apiKey;
        string postData;

        public void SetKey(string apiKey)
        {
            this.apiKey = apiKey;
        }

        private HttpWebRequest ToRequest(PinComandenum pinCommand)
        {
            var uri = ConfigurationManager.AppSettings["URI"];
            
            HttpWebRequest req = null;
            
            byte[] paramBytes = null;
            Stream requestStream = null; 
            
            switch (pinCommand)
            {
                case PinComandenum.Charges:
                    uri += "/1/charges";
                    req = HttpWebRequest.Create(uri) as HttpWebRequest;                    
                    req.Method = "GET";
                    break;
                case PinComandenum.Charge:
                    uri += "/1/charges/" + postData;
                    req = HttpWebRequest.Create(uri) as HttpWebRequest;
                    paramBytes = Encoding.UTF8.GetBytes(postData);
                    req.ContentLength = paramBytes.Length;

                    requestStream = req.GetRequestStream();
                    requestStream.Write(paramBytes, 0, paramBytes.Length);
                    break;
                case PinComandenum.ChargeSearch:
                    uri += "/1/charges/search";
                    if (postData != "")
                    {
                        uri += "?" + postData;
                    }
                    req = HttpWebRequest.Create(uri) as HttpWebRequest;
                    req.Method = "GET";
                    break;
            }
            req.ContentType = "application/x-www-form-urlencoded";
            req.UserAgent = "C# API Wrapper v001";
            req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(PinPaymentsConfig.GetApiKey() + ":"));

            return req;
        }

        public string Execute(PinComandenum pinCommand, string param)
        {
            this.postData = param;
            return Execute(pinCommand);
        }

        public string Execute(PinComandenum pinCommand, PostCharge c)
        {
            /*
            postData = "amount=" + c.amount + "&currency=" + c.currency + "&description=" + c.description + "&email=" + c.email + "&ip_address=" + c.ip_address;
            postData += "&card[number]=" + c.Card.number + "&card[expiry_month]=" + c.Card.Expiry_month + "&card[expiry_year]=" + c.Card.Expiry_year + "&card[cvc]=" + c.Card.cvc + "&card[name]=" + c.Card.Name;
            postData += "&card[address_line1]=" + c.Card.Address_line1 + "&card[address_line2]=" + c.Card.Address_line2 + "&card[address_city]=" + c.Card.Address_city + "&card[address_postcode]=" + c.Card.Address_postcode;
            postData += "&card[address_state]=" + c.Card.Address_state + "&card[address_country]=" + c.Card.Address_country;
          
            return Execute(pinCommand);
        }

        public string Execute(PinComandenum pinCommand)
        {
            Stream receiveStream = null;
            var req = ToRequest(pinCommand);
            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                receiveStream = response.GetResponseStream();
            }
            catch (WebException web) // 401 can throw exception
            {
                receiveStream = web.Response.GetResponseStream();
            }

            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string responsebody = readStream.ReadToEnd();

            postData = "";

            return responsebody;
        }
    }
     * * */

    
}
