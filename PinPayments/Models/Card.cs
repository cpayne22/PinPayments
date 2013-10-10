using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PinPayments.Models
{
    public class CardCreateResponse : PinError
    {
        public Card Response { get; set; }
    }

    [JsonObject("card")]
    public class Card
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("number")]
        public string CardNumber { get; set; }

        [JsonProperty("cvc")]
        public string CVC { get; set; }

        [JsonProperty("display_number")]
        public string DisplayNumber { get; set; }

        [JsonProperty("Expiry_month")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        public string ExpiryYear { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address_line1")]
        public string Address1 { get; set; }

        [JsonProperty("address_line2")]
        public string Address2 { get; set; }

        [JsonProperty("address_city")]
        public string City { get; set; }

        [JsonProperty("Address_postcode")]
        public string Postcode { get; set; }

        [JsonProperty("address_state")]
        public string State { get; set; }

        [JsonProperty("address_country")]
        public string Country { get; set; }

        [JsonProperty("scheme")]
        public string Scheme { get; set; }

        [JsonProperty("publishable_api_key")]
        public string APIKey { get; set; }
    }
}
