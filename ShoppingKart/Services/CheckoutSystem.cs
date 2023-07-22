using ShoppingKart.Concrete;
using ShoppingKart.Interfaces;

namespace ShoppingKart.Services
{

    public class CheckoutSystem : ICheckoutSystem
    {
        private readonly IDictionary<char, IItem> itemTable;
        private readonly IDictionary<char, int> scannedItems;

        public CheckoutSystem(IDictionary<char, IItem> itemTable)
        {
            this.itemTable = itemTable;
            scannedItems = new Dictionary<char, int>();
        }

        public void Scan(char item)
        {
            if (!itemTable.ContainsKey(item))
            {
                throw new InvalidItemException($"Invalid item: {item}");
            }

            if (!scannedItems.ContainsKey(item))
            {
                scannedItems[item] = 0;
            }

            scannedItems[item]++;
        }

        public double GetTotalPrice()
        {
            double totalPrice = 0.0;

            foreach (var itemEntry in scannedItems)
            {
                char item = itemEntry.Key;
                int quantity = itemEntry.Value;

                if (itemTable[item].Offer != null)
                {
                    IOffer offer = itemTable[item].Offer;
                    double itemPrice = itemTable[item].Price;
                    double totalOfferPrice = offer.GetTotalOfferPrice(quantity);
                   
                    totalPrice += totalOfferPrice + (quantity % offer.Quantity * itemPrice);
                }
                else
                {
                    totalPrice += quantity * itemTable[item].Price;
                }
            }

            return totalPrice;
        }
    }
}
