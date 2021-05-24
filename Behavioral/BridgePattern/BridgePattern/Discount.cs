using System;
using System.Collections.Generic;
using System.Text;

namespace BridgePattern
{
    public abstract class Discount
    {
        public abstract int GetDiscount();
    }

    public class NoDiscount : Discount
    {
        public override int GetDiscount() => 0;
    }

    public class MilitaryDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 10;
        }
    }

    public class SeniorDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 20;
        }
    }
}
