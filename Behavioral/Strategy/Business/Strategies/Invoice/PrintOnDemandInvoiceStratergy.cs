﻿using Newtonsoft.Json;
using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Strategy.Business.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStratergy : InvoiceStratergy
    {
        public override void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);

                client.BaseAddress = new Uri("https://pluralsight.com");

                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
