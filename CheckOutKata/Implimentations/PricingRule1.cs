

using CheckOutKata.Interfaces;
using System.Collections.ObjectModel;

namespace CheckOutKata.Implimentations
{
	public class PricingRule1 : IPricingRules
	{
		private readonly Dictionary<string, (int quantity, int specialPrice)> specialPrices;
		private readonly Dictionary<string, int> prices;

		public PricingRule1(Dictionary<string, int> prices, Dictionary<string, (int, int)> specialPrices)
		{
			this.prices = prices;
			this.specialPrices = specialPrices;
		}

		public int GetSpecialTotalPrice(string sku, int quantity)
		{
			
			int specialTotalPrice = 0;

			var specialPrice = specialPrices[sku];
			int specialPriceQuantity = specialPrice.quantity;
			int specialPriceValue = specialPrice.specialPrice;

			int specialPriceCount = quantity / specialPriceQuantity;
			int normalPriceCount = quantity % specialPriceQuantity;

			if (specialPriceCount > 0)
			{
				specialTotalPrice += specialPriceCount * specialPriceValue;
			}
			if (normalPriceCount > 0)
			{
				specialTotalPrice += normalPriceCount * prices[sku];
			}
			return specialTotalPrice;
		}
	}
}
