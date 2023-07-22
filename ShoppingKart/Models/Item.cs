using ShoppingKart.Interfaces;

namespace ShoppingKart.Models
{
    public class Item : IItem
    {
        public char SKU { get; }
        public double Price { get; }
        public IOffer? Offer { get; }

        public Item(char sku, double price) 
        {
            SKU = sku;
            this.Price = price;
        }

        public Item(char sku, double price, IOffer offer) : this(sku, price)
        {
            Offer = offer;
        }

    }

}
