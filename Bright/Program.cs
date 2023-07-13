// Define the pricing rules
using CheckOutKata.Implimentations;

var prices = new Dictionary<string, int>
{
	{ "A", 50 },
	{ "B", 30 },
	{ "C", 20 },
	{ "D", 15 }
};

var specialPrices = new Dictionary<string, (int, int)>
{
	{ "A", (3, 130) },
	{ "B", (2, 45) }
};

// Create a new checkout instance
var checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

// Scan items
checkout.Scan("A");
checkout.Scan("B");
checkout.Scan("A");
checkout.Scan("C");
checkout.Scan("B");
checkout.Scan("A");
checkout.Scan("A");
checkout.Scan("B");

// Get the total price
int totalPrice = checkout.GetTotalPrice();

Console.WriteLine($"Total price: {totalPrice} pounds");