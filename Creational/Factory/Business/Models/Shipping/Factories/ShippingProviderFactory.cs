using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method_Pattern.Business.Models.Shipping.Factories
{
    public abstract class ShippingProviderFactory
    {
        public abstract ShippingProvider CreateShippingProvider(string country);
        public ShippingProvider GetShippingProvider(string country)
        {
            var provider = CreateShippingProvider(country);

            //Option to change the provider for all the factory providers
            if(country == "Sweden" && provider.InsuranceOptions.ProviderHasInsurance)
            {
                provider.RequireSignature = false;
            }

            return provider;
        }
    }
}
