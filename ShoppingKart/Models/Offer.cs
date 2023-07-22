using ShoppingKart.Interfaces;

namespace ShoppingKart.Models
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

        public double GetTotalOfferPrice(int totalQuantity)
        {
            return totalQuantity / Quantity * offerPrice;
        }


    }
}
