using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassForPromotionEngine
{
    public class Engine
    {
        private IEnumerable<SKU_Price> PriceList;
        private IEnumerable<PromotionPlan> PromotionPlans;

        public Engine(IEnumerable<SKU_Price> priceList, IEnumerable<PromotionPlan> promotionsPlan)
        {
            this.PriceList = priceList;
            this.PromotionPlans = promotionsPlan;
        }

        public void CheckOut(Order order)  //Checkout: Calculate Total Amount
        {
            var foundItems = new List<Item>();
            if (PromotionPlans != null && PromotionPlans.Count() > 0)
                foreach (var promotionPlanItem in PromotionPlans)
                {
                    //Apply PromotionPlan into Orders, remove these orders from orderList
                    var validatedItems = promotionPlanItem.Validate(order, foundItems);
                    UpdateValidatedItems(foundItems, validatedItems);
                }
            //Calculate Total Amount from Order List
            ApplyRegularPrice(order, foundItems);
        }

        private void ApplyRegularPrice(Order order, List<Item> foundItems)
        {
            foreach (var item in order.Items)
            {
                var validateItem = foundItems.FirstOrDefault(x => x.SKU_Id == item.SKU_Id) ?? item;
                var quantity = validateItem.Quantity;
                if (quantity > 0)
                    order.TotalAmount += quantity * PriceList.First(x => x.SKU_Id == item.SKU_Id).UnitPrice;
            }
        }

        private static void UpdateValidatedItems(List<Item> foundItems, IEnumerable<Item> validatedItems)
        {
            if (validatedItems == null || validatedItems.Count() < 1)
                return;

            foreach (var item in validatedItems)
                if (!foundItems.Any(x => x.SKU_Id == item.SKU_Id))
                    foundItems.Add(item);
        }
    }
}
