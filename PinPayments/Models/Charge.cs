using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PinPayments.Actions;

namespace PinPayments.Models
{
    public class Charges:PinError
    {
        public Charge[] Response { get; set; }
        public int Count { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class ChargeResponse:PinError
    {
         [JsonProperty("response")]
        public Charge Charge{ get; set; }
    }

    public class PostCharge
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("ip_address")]
        public string IPAddress { get; set; }

        private string _currency { get; set; }

        [JsonProperty("currency")]
        public string Currency
        {
            get
            {
                if (_currency == null)
                {
                    return "AUD";
                }
                return _currency;
            }
            set { _currency = value; }
        }

        [JsonIgnore]
        public Card Card { get; set; }

        [JsonIgnore]
        public string CardToken { get; set; }

        [JsonIgnore]
        public string CustomerToken { get; set; }

    }

    public class ChargeDetail
    {
        public Charge Response { get; set; }
    }
    public class Charge
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ip_address")]
        public string IP_address { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("status_message")]
        public string Status { get; set; }

        [JsonProperty("card_token")]
        public string Card_Token { get; set; }

        [JsonProperty("customer_token")]
        public string Customer_Token { get; set; }

        public Card Card { get; set; }

    }
}
