﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Pattern.Business.Models.Shipping.Factories
{
    public class GlobalExpressShippingProviderFactory : ShippingProviderFactory
    {
        public override ShippingProvider CreateShippingProvider(string country)
        {
            return new GlobalExpressShippingProvider();
        }
    }
}
