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
    public class CRC32HelperTests
    {
        [TestMethod()]
        public void GetCRC32ByteTest()
        {
            uint result = CRC32Helper.CalculateCRC32(new byte[] { 0x68, 0xFF, 0xFF, 0xAB, 0x13, 0x26 });

            Assert.AreEqual(result, 0x27CB9B07u);
        }

        [TestMethod()]
        public void GetCRC32StringTest()
        {
            uint result = CRC32Helper.CalculateCRC32("123456789");

            Assert.AreEqual(result, 0xCBF43926u);
        }
    }
}