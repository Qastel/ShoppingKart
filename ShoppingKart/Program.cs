using ShoppingKart.Interfaces;
using ShoppingKart.Models;
using ShoppingKart.Services;

Dictionary<char, IItem> itemTable = new Dictionary<char, IItem>();
itemTable['A'] = new Item('A', 5.00, new Offer(3, 13.00));
itemTable['B'] = new Item('B', 3.00, new Offer(2, 4.5));
itemTable['C'] = new Item('C', 2.00);
itemTable['D'] = new Item('D', 1.50);


CheckoutSystem checkout = new CheckoutSystem(itemTable);
checkout.Scan('A');
checkout.Scan('B');
checkout.Scan('C');
checkout.Scan('C');

Console.WriteLine("Checkout total price {0}", checkout.GetTotalPrice());





