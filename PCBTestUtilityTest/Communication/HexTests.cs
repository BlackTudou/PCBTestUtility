using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.Comms.PCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microstar.Production.Tools;

namespace Microstar.Production.PCBTest.Tests
{
    [TestClass()]
    public class HexTests
    {
        [TestMethod()]
        public void FromStringTest()
        {
            //byte[] bytes = Hex.FromString("F4 24 4a 6c");

           // Assert.AreEqual(bytes[0], 0xF4);
           // Assert.AreEqual(bytes[1], 0x24);
           // Assert.AreEqual(bytes[2], 0x4a);
           // Assert.AreEqual(bytes[3], 0x6c);
        }

        [TestMethod()]
        public void Int2Hex4Test()
        {
            string result = Hex.Int2Hex4(228u);

            Assert.AreEqual(result,"00000031");
        }
    }
}