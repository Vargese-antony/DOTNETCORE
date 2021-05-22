using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype_Pattern
{
     public class FoodOrder: Prototype
    {
        public string customerName;
        public bool isDelivery;
        public string[] orderContents;
        public OrderInfo Info;
       

        public FoodOrder(string name, bool delivery, string[] contents, OrderInfo info)
        {
            this.customerName = name;
            this.isDelivery = delivery;
            this.orderContents = contents;
            this.Info = info;
        }

       

        public override void Debug()
        {
            Console.WriteLine("------- Prototype Food Order -------");
            Console.WriteLine("\nName: {0} \nDelivery: {1}", this.customerName, this.isDelivery);
            Console.WriteLine("ID: {0}", this.Info.Id);
            Console.WriteLine("Order Contents: " + string.Join(",", orderContents) + "\n");
        }

        public override Prototype ShallowCopy()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override Prototype DeepCopy()
        {
            var copy = (FoodOrder)this.MemberwiseClone();
            copy.Info = new OrderInfo(this.Info.Id);
            return copy;
        }
    }

    
}
