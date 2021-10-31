using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ClassForPromotionEngine;
using System;

namespace UnitTestForPromotionEngine
{
    [TestClass]
    public class UnitTest1
    {
        
        static readonly Engine priceCalculator = new Engine(DataItem.getPriceList(), DataItem.getPromotions());

        [TestMethod]
        public void TestCase01()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                {
            new Item { SKU_Id = 'A', Quantity = 1 },
            new Item { SKU_Id = 'B', Quantity = 1 },
            new Item { SKU_Id = 'C', Quantity = 1 }}
              };

            priceCalculator.CheckOut(order);
            Assert.IsTrue(order.TotalAmount == 100);
        }

        [TestMethod]
        public void TestCase02()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                {
            new Item { SKU_Id = 'A', Quantity = 5 },
            new Item { SKU_Id = 'B', Quantity = 5 },
            new Item { SKU_Id = 'C', Quantity = 1 }}
              };

            priceCalculator.CheckOut(order);
            Assert.IsTrue(order.TotalAmount == 370);
        }

        [TestMethod]
        public void TestCase03()
        {
            var order =
              new Order
              {
                  Items = new List<Item>
                {
            new Item { SKU_Id = 'A', Quantity = 3 },
            new Item { SKU_Id = 'B', Quantity = 5 },
            new Item { SKU_Id = 'C', Quantity = 1 },
            new Item { SKU_Id = 'D', Quantity = 1 }}
              };

            priceCalculator.CheckOut(order);
            Assert.IsTrue(order.TotalAmount == 280);
        }

        [TestMethod]
        public void TestCase04()
        {
            var order =
             new Order
             {
                 Items = new List<Item>
               {
                    new Item { SKU_Id = 'B', Quantity = 2 }
                }
             };

            priceCalculator.CheckOut(order);
            Assert.IsTrue(order.TotalAmount == 45);

        }

    }
}
