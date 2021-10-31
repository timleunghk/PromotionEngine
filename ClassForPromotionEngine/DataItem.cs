
using System.Collections.Generic;


namespace ClassForPromotionEngine
{
    public class DataItem
    {
        private static IEnumerable<SKU_Price> PriceList = new List<SKU_Price> {
            new SKU_Price { SKU_Id = 'A', UnitPrice = 50 },
            new SKU_Price { SKU_Id = 'B', UnitPrice = 30 },
            new SKU_Price { SKU_Id = 'C', UnitPrice = 20 },
            new SKU_Price { SKU_Id = 'D', UnitPrice = 15 }
        };

        private static IEnumerable<PromotionPlan> Promotions = new List<PromotionPlan> {
                new PromotionPlan {
                        Items = new List<Item> {
                            new Item { SKU_Id = 'A', Quantity = 3 }
                        },
                        TotalAmount = 130 }, // 3 of A for 130
                new PromotionPlan {
                    Items = new List<Item> {
                            new Item { SKU_Id = 'B', Quantity = 2}
                    },
                    TotalAmount = 45}, // 2 of B for 45
                new PromotionPlan {
                    Items = new List<Item> {
                        new Item { SKU_Id = 'C', Quantity = 1 },
                        new Item { SKU_Id = 'D', Quantity = 1 }
                    },
                    TotalAmount = 30 } }; // C + D for 30

        public static IEnumerable<SKU_Price> getPriceList()
        {
            return PriceList;
        }

        public static IEnumerable<PromotionPlan> getPromotions()
        {
            return Promotions;
        }

        public string getStatus()
        {
            return "OK";
        }
    }
}
