using System;
using System.Collections.Generic;
using ClassForPromotionEngine;

namespace ConsoleTestPromotionEngine
{
    class ConsoleProgram
    {

        static readonly Engine priceCalculator = new Engine(DataItem.getPriceList(), DataItem.getPromotions());

        static void Main(string[] args)
        {
            int qty_A = 0;
            int qty_B = 0;
            int qty_C = 0;
            int qty_D = 0;
            try
            {
                Console.WriteLine("Welcome to Promotion Engine");
                Console.WriteLine("How many of Item A will you buy?");
                if (!int.TryParse(Console.ReadLine(), out qty_A))
                {
                    qty_A = 0;
                }


                Console.WriteLine("How many of Item B will you buy?");
                if (!int.TryParse(Console.ReadLine(), out qty_B))
                {
                    qty_B = 0;
                }
                Console.WriteLine("How many of Item C will you buy?");
                if (!int.TryParse(Console.ReadLine(), out qty_C))
                {
                    qty_C = 0;
                }
                Console.WriteLine("How many of Item D will you buy?");
                if (!int.TryParse(Console.ReadLine(), out qty_D))
                {
                    qty_D = 0;
                }
                var order = new Order{
                            Items = new List<Item>
                                    {
                                        new Item { SKU_Id = 'A', Quantity = qty_A },
                                        new Item { SKU_Id = 'B', Quantity = qty_B },
                                        new Item { SKU_Id = 'C', Quantity = qty_C },
                                        new Item { SKU_Id = 'D', Quantity = qty_D },
                                    }
                            };
                priceCalculator.CheckOut(order);
                Console.WriteLine("Total Amount is ${0}. Thank you!", order.TotalAmount);



            }
            catch (Exception e)
            {
                Console.WriteLine("Please type integer value");
            }
            
        }
    }


   
}
