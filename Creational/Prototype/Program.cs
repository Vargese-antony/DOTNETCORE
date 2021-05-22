using System;

namespace Prototype_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Original Order");
            var originalFood = new FoodOrder("Jammy", true, new string[] { "soda", "sweet" }, new OrderInfo(2345));
            originalFood.Debug();

            Console.WriteLine("Cloned Order");
            var cloned = originalFood.DeepCopy();
            cloned.Debug();

            originalFood.customerName = "Tom";
            originalFood.Info.Id = 3456;

            originalFood.Debug();
            cloned.Debug();*/

            //###########Object pool pattern#################

            PrototypeManager manager = new PrototypeManager();
            manager["19/6/2021"] = new FoodOrder("Jammy", true, new string[] { "soda", "sweet" }, new OrderInfo(2345));
            manager["19/6/2021"].Debug();

            FoodOrder newOrder = (FoodOrder)manager["19/6/2021"].DeepCopy();
            newOrder.Debug();

        }
    }
}
