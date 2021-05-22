using Factory_Method_Pattern.Business.Models.Commerce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Pattern.Business.Models.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "GLOBAL-EXPRESS";
        }
    }
}
