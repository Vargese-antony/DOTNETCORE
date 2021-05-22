using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Template;

namespace TemplateTests
{
    [TestClass()]
    public class PizzaBakingServiceTests
    {
        [TestMethod()]
        public void PreparePizzaTest()
        {
            var service = new PizzaBakingService();
            var pizza = service.Prepare();

            Assert.IsNotNull(pizza);
        }
    }
}
