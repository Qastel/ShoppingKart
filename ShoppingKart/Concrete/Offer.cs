using ShoppingKart.Interfaces;

namespace ShoppingKart.Concrete
{
    public class Offer : IOffer
    {
        public int Quantity { get; }
        private readonly double offerPrice;

        public Offer(int quantity, double offerPrice)
        {
            Quantity = quantity;
            this.offerPrice = offerPrice;
        }

        public double GetOfferPrice(int quantity)
        {
            int offerApplications = quantity / Quantity;
            int remainingItems = quantity % Quantity;

            return offerApplications * offerPrice + remainingItems * offerPrice;
        }


    }
}
