using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Business.Strategies.Invoice
{
    public interface IInvoiceStratergy
    {
        public void Generate(Order order);
    }
}
