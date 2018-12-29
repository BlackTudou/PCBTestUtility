using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microstar.Production.Tools.Tests
{
    [TestClass()]
    public class CSHelperTests
    {
        [TestMethod()]
        public void CalculateCSTest()
        {
            byte cs = CSHelper.CalculateCS(new byte[] { 0x68, 0xFF, 0xFF, 0xAA, 0xBB, 0xCC, 0xDD, 0xEE, 0xFF, 0xCC });
            Assert.AreEqual(cs, 0x2D);
        }
    }
}