PinPayments Library
==========

The PinPayments Library is a .net wrapper for http://pinpayments.com. 

For more information about the examples below, you can visit https://pinpayments.com/docs/api for a full reference.

(Inspiration and thanks to Jayme Davis's Stripe implemetnation:  https://github.com/jaymedavis/stripe.net)

Quick Start
-----------

a) Obtain either your Publish key or your Secret key (see the differences here: https://pinpayments.com/docs/api)

b) Update your AppSetting with your api key to your config (this is the easiest way)

	<appSettings>
	...
		<add key="Secret_API" value="** ENTER YOUR SECRET API KEY **"/>
	...
	</appSettings>

	
c) In your application initialization, call (this is a programmatic way, but you only have to do it once during startup)

	PinService ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);

	or
	
	PinService ps = new PinService();
	
	
Examples
========

Charges
-----

### Charging a card

	PinService ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);

	// https://pinpayments.com/docs/api/test-cards
	// 5520000000000000 - Mastercard
	// 4200000000000000 - Visa

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

    var response = ps.Charge(new PostCharge { Amount = 100, Card = card, Currency = "AUD", Description = "Desc", Email = "email@test.com", IPAddress = "127.0.0.1" });
	System.Console.WriteLine(response.Charge.success);

	
### Charge Search

	// See https://pinpayments.com/docs/api/charges#search-charges for more detail
    PinService ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);

    var cs = new PinPayments.ChargeSearch { Query = "", Sort = ChargeSearchSortEnum.Amount, SortDirection = SortDirectionEnum.Descending };
    var response = ps.ChargesSearch(cs);
    System.Console.WriteLine(response.Count.ToString() + " transactions found");
    foreach (var r in response.Response)
    {
        System.Console.WriteLine(r.description + " " + r.amount.ToString());
    }
	
	
Customers
-----

### Listing all customers
    // See https://pinpayments.com/docs/api/customers#get-customers
    ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);
    var customers = ps.Customers();
	
	
### Adding a new customer
	
    // See https://pinpayments.com/docs/api/customers#post-customers for more detail
    ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);

    var customer = new Customer();
    customer.Email = "roland@pinpayments.com";
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

    var response = ps.CustomerAdd(customer);

    System.Console.WriteLine("Customer token: " + response.Customer.Token);

	
### Updating a customer

    // See https://pinpayments.com/docs/api/customers#put-customer
    ps = new PinService(ConfigurationManager.AppSettings["Secret_API"]);
    var customers = ps.Customers();
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
    var customerUpate = ps.CustomerUpate(customer);            


### Refunds

    // Refunds - Pin supports partial refunds
    // https://pinpayments.com/docs/api/customers#get-customers-charges

    var refund = ps.Refund("INSERT CHARGE TOKEN", 200);
    refund = ps.Refund("INSERT CHARGE TOKEN", 100);

	
	// Lists all refunds for a particular charge
    var refunds = ps.Refunds("INSERT CHARGE TOKEN");
	
	
### Card Tokens

    // Card Token
    // https://pinpayments.com/docs/api/cards
    // 5520000000000000 - Test Mastercard
    // 4200000000000000 - Test Visa

    card = new Card();
    card.APIKey = ""; // OPTIONAL.  Your publishable API key, if requesting from an insecure environment.
    card.CardNumber = "5520000000000000";
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
	
	
	
Errors
------

Any errors that occur on any of the services will throw a PinException with the message returned from Pin. It is a good idea to run your service calls in a try and catch PinExceptions.

