using CheckOutKata.Implimentations;
using CheckOutKata.Interfaces;

namespace TestProject1
{
	public class CheckoutTests
	{
		private ICheckout? checkout;


		[Test]
		public void ScanNoItems_TotalIs0()
		{
			var prices = new Dictionary<string, int>();

			var specialPrices = new Dictionary<string, (int, int)>();
			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));
			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(0));
		}

		[Test]
		public void ScanSingleItemWithSimplePrice_TotalIsEqualItemPrice()
		{

			var prices = new Dictionary<string, int> { { "A", 50 } };
			var specialPrices = new Dictionary<string, (int, int)>();

			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

			checkout.Scan("A");

			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(50));
		}

		[Test]
		public void Scan2ItemsWithSimplePrice_TotalIsEqual2TimesItemPrice()
		{
			var prices = new Dictionary<string, int> { { "A", 50 } };
			var specialPrices = new Dictionary<string, (int, int)>();

			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

			checkout.Scan("A");
			checkout.Scan("A");

			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(100));
		}

		[Test]
		public void Scan2DifferentItemsWithSimplePrice_TotalIsEqualSumOfItemPrices()
		{
			var prices = new Dictionary<string, int> { { "A", 50 }, { "B", 20 } };
			var specialPrices = new Dictionary<string, (int, int)>();

			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

			checkout.Scan("A");
			checkout.Scan("B");

			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(70));
		}

		[Test]
		public void Scan2ItemsWhichTogetherHaveASpecialPrice_TotalIsEqualToSpecialPrice()
		{
			var prices = new Dictionary<string, int> { { "B", 25 } };
			var specialPrices = new Dictionary<string, (int, int)> { { "B", (2, 45) } };

			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

			checkout.Scan("B");
			checkout.Scan("B");

			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(45));
		}

		[Test]
		public void Scan2ItemsWhichTogetherHaveASpecialPriceAndItemWithSimplePrice_TotalIsCorrect()
		{
			var prices = new Dictionary<string, int> { { "A", 10 },{ "B", 25 } };
			var specialPrices = new Dictionary<string, (int, int)> { { "B", (2, 45) } };

			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

			checkout.Scan("B");
			checkout.Scan("B");
			checkout.Scan("A");

			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(45 + 10));
		}

		[Test]
		public void Scan3ItemsWhere2HaveASpecialPriceAndThirdHasRegularPrice_TotalIsCorrect()
		{
			var prices = new Dictionary<string, int> { { "B", 10 } };
			var specialPrices = new Dictionary<string, (int, int)> { { "B", (2, 17) } };

			checkout = new Checkout(prices, specialPrices, new PricingRule1(prices, specialPrices));

			checkout.Scan("B");
			checkout.Scan("B");
			checkout.Scan("B");

			Assert.That(checkout.GetTotalPrice(), Is.EqualTo(17 + 10));
		}

	}
}