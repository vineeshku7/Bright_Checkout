
namespace CheckOutKata.Interfaces
{

	public interface IPricingRules
	{
		int GetSpecialTotalPrice(string sku, int quantity);

	}
}
