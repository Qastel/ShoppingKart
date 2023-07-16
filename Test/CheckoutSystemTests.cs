namespace Test
{
    using NUnit.Framework;
    using ShoppingKart.Concrete;
    using ShoppingKart.Interfaces;
    using System.Collections.Generic;

    [TestFixture]
    public class CheckoutSystemTests
    {
        private IDictionary<char, IItem> priceTable;
        private IDictionary<char, IOffer> offerTable;

        [SetUp]
        public void Setup()
        {
            priceTable = new Dictionary<char, IItem>();
            offerTable = new Dictionary<char, IOffer>();

            priceTable['A'] = new Item('A', 5.00);
            priceTable['B'] = new Item('B', 3.00);
            priceTable['C'] = new Item('C', 2.00);
            priceTable['D'] = new Item('D', 1.50);

            offerTable['A'] = new Offer(3, 13.00);
            offerTable['B'] = new Offer(2, 4.50);
        }

        [Test]
        public void GetTotalPrice_NoOffers_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            CheckoutSystem checkout = new CheckoutSystem(priceTable, null);
            checkout.Scan('A');
            checkout.Scan('B');
            checkout.Scan('C');
            checkout.Scan('D');

            // Act
            double totalPrice = checkout.GetTotalPrice();

            // Assert
            Assert.That(totalPrice, Is.EqualTo(11.50));
        }

        [Test]
        public void GetTotalPrice_WithOffers_ShouldReturnCorrectTotalPrice()
        {
            // Arrange
            CheckoutSystem checkout = new CheckoutSystem(priceTable, offerTable);
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
            Assert.That(totalPrice, Is.EqualTo(21));
        }

        [Test]
        public void GetTotalPrice_InvalidItem_ShouldThrowInvalidItemException()
        {
            // Arrange
            CheckoutSystem checkout = new CheckoutSystem(priceTable, offerTable);

            // Act and Assert
            Assert.Throws<InvalidItemException>(() => checkout.Scan('X'));
        }
    }

}