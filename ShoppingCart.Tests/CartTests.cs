using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTests
    {
        private static CartManager _cartManager;
        private static int id = 0;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _cartManager = new CartManager();
        }

        [TestMethod]
        public void When_a_product_is_added_to_the_card_the_number_of_the_products_in_the_card_must_increase()
        {
            var quantity = _cartManager.TotalQuantity;

            id++;
            _cartManager.Add(new CartItem
            {
                Product = new Product
                {
                    ProductId = id,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            });

            Assert.AreEqual(quantity + 1, _cartManager.TotalQuantity);
        }

        [TestMethod]
        public void When_a_product_is_removed_from_the_card_the_product_number_of_the_card_must_decrease()
        {
            var quantity = _cartManager.TotalQuantity;

            _cartManager.Remove(id);
            id--;

            Assert.AreEqual(quantity - 1, _cartManager.TotalQuantity);
        }

        [TestMethod]
        public void When_the_card_is_cleared_the_products_of_the_card_must_be_cleared()
        {
            _cartManager.Clear();

            Assert.AreEqual(0, _cartManager.TotalItems);
            Assert.AreEqual(0, _cartManager.TotalQuantity);
        }
    }
}

// Ordered List