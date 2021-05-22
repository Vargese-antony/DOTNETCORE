using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Business.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTax(Order order);
    }
}
