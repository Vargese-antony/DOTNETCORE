using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    public class Pie: BakedPanFood { }
    
    public class PieBakingService: PanBankingServiceBase<Pie>
    {
        protected override void AddToppings()
        {
            Console.WriteLine("Inside Pie:AddToppings");
        }

        protected override void Bake()
        {
            Console.WriteLine("Inside Pie:Bake");
        }

        protected override void PrepareCrust()
        {
            Console.WriteLine("Inside Pie:PrepareCrust");
        }

        protected override void Slice()
        {
            Console.WriteLine("Inside Pie:Slice");
        }

        protected override void Cover()
        {
            Console.WriteLine("Inside Pie:Cover");
        }
    }
}
