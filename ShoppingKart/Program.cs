using ShoppingKart.Concrete;
using ShoppingKart.Interfaces;

Dictionary<char, IItem> priceTable = new Dictionary<char, IItem>();
priceTable['A'] = new Item('A', 5.00);
priceTable['B'] = new Item('B', 3.00);
priceTable['C'] = new Item('C', 2.00);
priceTable['D'] = new Item('D', 1.50);

Dictionary<char, IOffer> offerTable = new Dictionary<char, IOffer>();
offerTable['A'] = new Offer(3, 13.00);
offerTable['B'] = new Offer(2, 4.50);


CheckoutSystem checkout = new CheckoutSystem(priceTable, offerTable);
checkout.Scan('A');
checkout.Scan('B');
checkout.Scan('C');
checkout.Scan('C');

Console.WriteLine("Checkout total price {0}", checkout.GetTotalPrice());





