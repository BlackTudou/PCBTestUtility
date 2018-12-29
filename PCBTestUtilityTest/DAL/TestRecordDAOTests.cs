using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.PCBTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microstar.Production.PCBTest.Model;

namespace Microstar.Production.PCBTest.DAL.Tests
{
    [TestClass()]
    public class TestRecordDAOTests
    {
        [TestMethod()]
        public void SelectTestRecordTest()
        {
            var dataTable = TestRecordDAO.Instance.SelectTestRecords(2, 10);

            var testRecordList = new List<TestRecord>();
            foreach (DataRow dr in dataTable.Rows)
            {
                TestRecord testRecord = new TestRecord();
                testRecord.ID = (int)dr["ID"];
                testRecord.MeterNumber = dr["meter_number"].ToString();
                testRecord.InspectorNumber = (int)dr["inspector_number"];
                testRecord.CustomerCode = dr["customer_code"].ToString();
                testRecord.Time = (DateTime)dr["test_time"];
                testRecord.Items = dr["test_items"].ToString();
                testRecord.Result = dr["test_result"].ToString();
                testRecord.DetailedInformation = dr["detail_info"].ToString();

                testRecordList.Add(testRecord);
            }

            Assert.Fail();
        }

        [TestMethod()]
        public void InsertTestRecordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SelectTestRecordTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTestRecordCountTest()
        {
            TestRecordDAO.Instance.GetTestRecordsCount();
            Assert.Fail();
        }
    }
}