using Microsoft.VisualStudio.TestTools.UnitTesting;
using Template;
using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Tests
{
    [TestClass()]
    public class PieBakingServiceTests
    {
        [TestMethod()]
        public void PreparePieTest()
        {
            var service = new PieBakingService();
            var pie = service.Prepare();

            Assert.IsNotNull(pie);
        }
    }
}