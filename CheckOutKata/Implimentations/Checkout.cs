using CheckOutKata.Interfaces;


namespace CheckOutKata.Implimentations
{
	public class Checkout : ICheckout
	{
		private readonly IPricingRules pricingRules;

		private Dictionary<string, int> prices;
		private Dictionary<string, (int quantity, int specialPrice)> specialPrices;
		private Dictionary<string, int> scannedItems;

		public Checkout(Dictionary<string, int> prices, Dictionary<string, (int, int)> specialPrices, IPricingRules pricingRule)
		{
			pricingRules = pricingRule;
			this.prices = prices;
			this.specialPrices = specialPrices;
			scannedItems = new Dictionary<string, int>();
		}

		public void Scan(string item)
		{
			if (prices.ContainsKey(item))
			{
				if (scannedItems.ContainsKey(item))
				{
					scannedItems[item]++;
				}
				else
				{
					scannedItems[item] = 1;
				}
			}
			else
			{
				throw new KeyNotFoundException($"Item '{item}' not found.");
			}
		}

		public int GetTotalPrice()
		{
			int totalPrice = 0;

			foreach (var item in scannedItems)
			{
				string sku = item.Key;
				int quantity = item.Value;

				if (specialPrices.ContainsKey(sku))
				{
					totalPrice += pricingRules.GetSpecialTotalPrice(sku, quantity);
				}
				else
				{
					totalPrice += quantity * prices[sku];
				}
			}

			return totalPrice;
		}
	}
}
