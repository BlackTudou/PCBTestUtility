using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.PCBTest.Command;
using Microstar.Production.PCBTest.Model;
using Microstar.Production.View;
using System;
using System.Collections.Generic;

namespace Microstar.Production.PCBTest.Tests
{
    [TestClass()]
    public class MainFormTests
    {
        private static Lazy<Dictionary<string, CommandParameter>> parameterDictionary = new Lazy<Dictionary<string, CommandParameter>>(() => new Dictionary<string, CommandParameter>());
        private Dictionary<string, CommandParameter> InitializeParameterDictionary()  //项目名称，参数
        {
            if (!parameterDictionary.IsValueCreated)
            {
                parameterDictionary.Value.Add("Phase A power consumption", new MeasureParameter(Phase.A));


            }
            return parameterDictionary.Value;
        }

        [TestMethod()]
        public void ExcuteTestTest()
        {
            List<TestItemInfo> infos = new List<TestItemInfo>();
            Dictionary<string, CommandParameter> parameterDict = InitializeParameterDictionary();

            infos.Add(new TestItemInfo
            { Parameter = parameterDict["Phase A power consumption"] });
#if false
            infos.Add(new TestItemInfo
            { ResourceId = "item002" });


            infos.Add(new TestItemInfo
            { ResourceId = "item003" });

            infos.Add(new TestItemInfo
            { ResourceId = "item004" });
#endif


            //MainForm.ExcuteTest(infos);

            Assert.Fail();
        }

        /// <summary>
        /// 测试插入数据到数据库
        /// </summary>
        [TestMethod()]
        public void InsertDataToDatabaseTest()
        {
            MainForm mainForm = new MainForm();

            DateTime currentTime = new DateTime();
            currentTime = System.DateTime.Now;

            TestRecord information = new TestRecord()
            {
                MeterNumber = "123456789",
                InspectorNumber = 105641,
                CustomerCode = "0600",
                Time = currentTime,
                Items = "pulse",
                Result = "success",
                DetailedInformation = "detail"
            };

            //int value = mainForm.InsertDataToDatabase(information);
            //Assert.AreEqual(value,1);
        }
    }
}