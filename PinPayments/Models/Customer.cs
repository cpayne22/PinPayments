using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PinPayments.Actions;

namespace PinPayments.Models
{
    public class Customers
    {
        [JsonProperty("response")]
        public Customer[] Customer { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class CustomerAdd:PinError
    {
        public Customer Response { get; set; }
    }
    public class Customer
    {
        public Customer()
        {
            _card = new Card();
        }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("created_at")]
        public DateTime? DateCreated { get; set; }

        private Card _card;

        public Card Card
        {
            get { return _card; }
            set
            {
                if (value == null)
                {
                    _card = new Card();
                }
                else
                {
                    _card = value;
                }

            }
        }

        [JsonProperty("card[number]")]
        public string CardNumber { get { return Card.CardNumber; } set { Card.CardNumber = value; } }

        [JsonIgnore]
        public string DisplayNumber { get { return Card.DisplayNumber; }  }

        [JsonProperty("card[expiry_month]")]
        public string ExpiryMonth { get { return Card.ExpiryMonth; } set { Card.ExpiryMonth = value; } }

        [JsonProperty("card[expiry_year]")]
        public string ExpiryYear { get { return Card.ExpiryYear; } set { Card.ExpiryYear = value; } }

        [JsonProperty("card[cvc]")]
        public string CVC { get { return Card.CVC; } set { Card.CVC = value; } }

        [JsonProperty("card[name]")]
        public string Name { get { return Card.Name; } set { Card.Name = value; } }

        [JsonProperty("card[address_line1]")]
        public string Address1 { get { return Card.Address1; } set { Card.Address1 = value; } }

        [JsonProperty("card[address_line2]")]
        public string Address2 { get { return Card.Address2; } set { Card.Address2 = value; } }

        [JsonProperty("card[address_city]")]
        public string City { get { return Card.City; } set { Card.City = value; } }

        [JsonProperty("card[address_postcode]")]
        public string Postcode { get { return Card.Postcode; } set { Card.Postcode = value; } }

        [JsonProperty("card[address_state]")]
        public string State { get { return Card.State; } set { Card.State = value; } }

        [JsonProperty("card[address_country]")]
        public string Country { get { return Card.Country; } set { Card.Country = value; } }
    }

    public class CustomerUpdate:Response
    {
        [JsonProperty("response")]
        public Customer Customer { get; set; }
    }
}
