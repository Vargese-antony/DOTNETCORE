using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public abstract class BakedPanFood { }
    public class Pizza: BakedPanFood { }
    public class PizzaBakingService: PanBankingServiceBase<Pizza>
    {
        protected override void AddToppings()
        {
            Console.WriteLine("Inside Pizza:AddToppings");
        }

        protected override void Bake()
        {
            Console.WriteLine("Inside Pizza:Bake");
        }

        protected override void PrepareCrust()
        {
            Console.WriteLine("Inside Pizza:PrepareCrust");
        }

        protected override void Slice()
        {
            Console.WriteLine("Inside Pizza:Slice");
        }
    }
}
