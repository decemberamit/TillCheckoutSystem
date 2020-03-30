using TillCheckoutSystem.Configuration;

namespace TillCheckoutSystem.CheckoutSystem
{
    public class Item
    {
        public decimal GetItemPrice(string itemType)
        {
            return decimal.Parse(AppConfigReader.Configuration[itemType]);
        }
    }
}
