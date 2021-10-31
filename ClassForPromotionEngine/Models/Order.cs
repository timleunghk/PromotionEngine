using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassForPromotionEngine
{
    public class Order
    {
        public List<Item> Items { get; set; }
        public double TotalAmount { get; set; }

        public override string ToString()
        {
            string itemsInfo = "";

            foreach (var item in Items)
            {
                itemsInfo += "Ordered Item:" + item.SKU_Id + "--" + item.Quantity + "\r\n";
            }

            return $"Ordered Information {itemsInfo} \r\nTotal Amount:{TotalAmount}";


        }
    }
}
