using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using PinPayments.Models;
using Newtonsoft.Json;
using PinPayments.Actions;

namespace PinPayments.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialise PIN by passing your API Key
            // See:  https://pin.net.au/docs/api#keys
            PinService ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);

            // https://pin.net.au/docs/api/test-cards
            // 5520000000000000 - Test Mastercard
            // 4200000000000000 - Test Visa

            var card = new Card();
            card.CardNumber = "5520000000000000";
            card.CVC = "111";
            card.ExpiryMonth = DateTime.Today.Month.ToString();  // Use the real Expiry
            card.ExpiryYear = (DateTime.Today.Year + 1).ToString(); // Not my defaults!
            card.Name = "Roland Robot";
            card.Address1 = "42 Sevenoaks St";
            card.Address2 = null;
            card.City = "Lathlain";
            card.Postcode = "6454";
            card.State = "WA";
            card.Country = "Australia";

            var response = ps.Charge(new PostCharge { Amount = 1500, Card = card, Currency = "AUD", Description = "Desc", Email = "email@test.com", IPAddress = "127.0.0.1" });
            System.Console.WriteLine(response.Charge.Success);


            // Refunds - Pin supports partial refunds
            // https://pin.net.au/docs/api/customers#get-customers-charges

            var refund = ps.Refund(response.Token, 200);
            refund = ps.Refund(response.Token, 100);

            var refunds = ps.Refunds(response.Token);

            // Searching for a Charge
            // See https://pin.net.au/docs/api/charges#search-charges for more detail

            var respChargesSearch = ps.ChargesSearch(new Actions.ChargeSearch { Query = "", Sort = ChargeSearchSortEnum.Amount, SortDirection = SortDirectionEnum.Descending });
            System.Console.WriteLine(respChargesSearch.Count.ToString() + " transactions found");
            foreach (var r in respChargesSearch.Response)
            {
                System.Console.WriteLine(r.Description + " " + r.Amount.ToString());
            }

            var respChargeSearch = ps.Charge(respChargesSearch.Response[0].Token);
            System.Console.WriteLine(respChargeSearch.Response.Description);


            // Create Customer
            // See: https://pin.net.au/docs/api/customers#post-customers

            var customer = new Customer();
            customer.Email = "roland@pin.net.au";
            customer.Card = new Card();
            customer.Card.CardNumber = "5520000000000000";
            customer.Card.ExpiryMonth = "05";
            customer.Card.ExpiryYear = "2014";
            customer.Card.CVC = "123";
            customer.Card.Name = "Roland Robot";
            customer.Card.Address1 = "42 Sevenoaks St";
            customer.Card.Address2 = "";
            customer.Card.City = "Lathlain";
            customer.Card.Postcode = "6454";
            customer.Card.State = "WA";
            customer.Card.Country = "Australia";

            var respCustomer = ps.CustomerAdd(customer);
            System.Console.WriteLine("Customer token: " + respCustomer.Response.Token);

            // Get Customer
            var customers = ps.Customers();

            // Customers supports pagination
            if (customers.Pagination.Pages > 1)
            {
                customers = ps.Customers(1);
            }

            // Update Customer
            customer = customers.Customer[0];

            customer.Card = new Card();
            customer.Card.CardNumber = "5520000000000000";
            customer.Card.ExpiryMonth = "05";
            customer.Card.ExpiryYear = "2014";
            customer.Card.CVC = "123";
            customer.Card.Name = "Roland Robot";
            customer.Card.Address1 = "42 Sevenoaks St";
            customer.Card.Address2 = "";
            customer.Card.City = "Lathlain";
            customer.Card.Postcode = "6454";
            customer.Card.State = "WA";
            customer.Card.Country = "Australia";

            customer.State = "NSW";
            var customerUpdate = ps.CustomerUpdate(customer);

            // Get a customer by token
            var current = ps.Customer(customerUpdate.Customer.Token);
            
            var respCustomerCharge = ps.Charge(new PostCharge { IPAddress = "127.0.0.1", Amount = 1000, Description = "Charge by customer token: " + customer.Email, Email = customer.Email, CustomerToken = customer.Token });

            // Card Token
            // https://pin.net.au/docs/api/cards
            // 5520000000000000 - Test Mastercard
            // 4200000000000000 - Test Visa

            card = new Card();
            card.APIKey = ""; // OPTIONAL.  Your publishable API key, if requesting from an insecure environment.
            // card.CardNumber = "5520000000000000";
            card.CVC = "111";
            card.ExpiryMonth = DateTime.Today.Month.ToString();  // Use the real Expiry
            card.ExpiryYear = (DateTime.Today.Year + 1).ToString(); // Not my defaults!
            card.Name = "Roland Robot";
            card.Address1 = "42 Sevenoaks St";
            card.Address2 = "";
            card.City = "Lathlain";
            card.Postcode = "6454";
            card.State = "WA";
            card.Country = "Australia";

            var respCardCreate = ps.CardCreate(card);

            response = ps.Charge(new PostCharge { Amount = 1500, CardToken = card.Token, Currency = "AUD", Description = "Desc", Email = "email@test.com", IPAddress = "127.0.0.1" });
            System.Console.WriteLine(response.Charge.Success);

            // Card tokens can only be used once.
            // If you try and use it a second time, you will get the following message:
            response = ps.Charge(new PostCharge { Amount = 1500, CardToken = card.Token, Currency = "AUD", Description = "Desc", Email = "email@test.com", IPAddress = "127.0.0.1" });
            System.Console.WriteLine(response.Error); // "token_already_used"
            System.Console.WriteLine(response.Description); // "Token already used. Card tokens can only be used once, to create a charge or assign a card to a customer."



        }
    }
}
