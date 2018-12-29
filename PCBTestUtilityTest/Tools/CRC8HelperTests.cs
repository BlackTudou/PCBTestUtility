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
    public class CRC8HelperTests
    {
        [TestMethod()]
        public void CalcCRC8Test()
        {
            byte[] bytes = new byte[] { 0x12, 0x34, 0x56, 0x78 };
            byte crc = CRC8Helper.CalculateCRC8(bytes);
            Assert.AreEqual(crc, 0x98);
        }
    }
}