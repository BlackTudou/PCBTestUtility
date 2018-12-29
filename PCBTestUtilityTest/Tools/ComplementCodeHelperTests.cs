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
    public class ComplementCodeHelperTests
    {
        [TestMethod()]
        public void CalcComplementCodeTest()
        {
            decimal result = ComplementCodeHelper.CalcComplementCode(12.646412321m);
            Assert.AreEqual(result,12m);
        }
    }
}