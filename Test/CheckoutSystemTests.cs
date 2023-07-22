namespace Test
{
    using NUnit.Framework;
    using ShoppingKart.Concrete;
    using ShoppingKart.Interfaces;
    using ShoppingKart.Models;
    using ShoppingKart.Services;
    using System.Collections.Generic;

    [TestFixture]
    public class CheckoutSystemTests
    {
        private IDictionary<char, IItem> itemTable;

        [SetUp]
        public void Setup()
        {
            itemTable = new Dictionary<char, IItem>();
          
            itemTable['A'] = new Item('A', 5.00, new Offer(3, 13.00));
            itemTable['B'] = new Item('B', 3.00, new Offer(2, 4.50));
            itemTable['C'] = new Item('C', 2.00);
            itemTable['D'] = new Item('D', 1.50);

        }

        [Test]
        public void GetTotalPrice_NoOffers_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            CheckoutSystem checkout = new CheckoutSystem(itemTable);
            checkout.Scan('C');
            checkout.Scan('C');
            checkout.Scan('D');

            // Act
            double totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(5.50));
        }

        [Test]
        public void GetTotalPrice_WithOffers_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            CheckoutSystem checkout = new CheckoutSystem(itemTable);
            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('B');
            checkout.Scan('B');
            checkout.Scan('C');
            checkout.Scan('D');

            // Act
            double totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(26));
        }

        [Test]
        public void GetTotalPrice_InvalidItem_ShouldThrowInvalidItemException()
        {
            // Arrange
            CheckoutSystem checkout = new CheckoutSystem(itemTable);

            // Act and Assert
            Assert.Throws<InvalidItemException>(() => checkout.Scan('X'));
        }
    }

}