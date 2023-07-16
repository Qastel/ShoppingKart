using ShoppingKart.Interfaces;

namespace ShoppingKart.Concrete
{
    public class Item : IItem
    {
        public char SKU { get; }
        private readonly double price;

        public Item(char sku, double price)
        {
            SKU = sku;
            this.price = price;
        }

        public double GetPrice()
        {
            return price;
        }
    }

}
