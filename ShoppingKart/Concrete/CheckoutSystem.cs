using ShoppingKart.Interfaces;
namespace ShoppingKart.Concrete
{

    public class CheckoutSystem : ICheckoutSystem
    {
        private readonly IDictionary<char, IItem> priceTable;
        private readonly IDictionary<char, IOffer> ?offerTable;
        private readonly IDictionary<char, int> scannedItems;

        public CheckoutSystem(IDictionary<char, IItem> priceTable, IDictionary<char, IOffer> ?offerTable)
        {
            this.priceTable = priceTable;
            this.offerTable = offerTable;
            scannedItems = new Dictionary<char, int>();
        }

        public void Scan(char item)
        {
            if (!priceTable.ContainsKey(item))
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

                if (offerTable!= null && offerTable.ContainsKey(item))
                {
                    IOffer offer = offerTable[item];
                    double itemPrice = priceTable[item].GetPrice();
                    double offerPrice = offer.GetOfferPrice(quantity);

                    totalPrice += offerPrice;
                    totalPrice += quantity % offer.Quantity * itemPrice;
                }
                else
                {
                    totalPrice += quantity * priceTable[item].GetPrice();
                }
            }

            return totalPrice;
        }
    }
}
