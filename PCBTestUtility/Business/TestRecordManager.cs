/*
 * Copyright (C) 1994-2018 Microstar Electric Company Limited
 * 
 * All Rights Reserved.
 * 
 * LEGAL NOTICE: All information contained herein is, and 
 * remains the property of Microstar Electric Company Limited. 
 * The intellectual and technical concepts contained herein 
 * are proprietary to Microstar Electric Company Limited, and 
 * may be covered by patents, patents in process and are 
 * protected by the trade secret or copyright laws. Commercial 
 * use, or disclosure, or dissemination, or reproduction of 
 * the information contained in this file are strictly 
 * forbidden unless official specific written permissions are 
 * obtained from Microstar Electric Company Limited.
 */

using Microstar.Production.PCBTest.DAL;
using Microstar.Production.PCBTest.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Microstar.Production.PCBTest.Business
{
    /// <summary>
    /// 检测记录业务层
    /// </summary>
    public sealed class TestRecordManager
    {
        private static Lazy<TestRecordManager> instance = new Lazy<TestRecordManager>(() => new TestRecordManager());

        private TestRecordDAO testRecordDAO = TestRecordDAO.Instance;

        /// <summary>
        /// 获取TestRecordManager实例
        /// </summary>
        public static TestRecordManager Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// 防止直接调用构造函数
        /// </summary>
        private TestRecordManager()
        { }

        /// <summary>
        /// 将检测结果传入数据库
        /// </summary>
        /// <param name="testRecord">检测记录</param>
        /// <returns>表中受影响的行数</returns>
        public int InsertTestRecord(TestRecord testRecord)
        {
            return testRecordDAO.InsertTestRecord(testRecord);
        }

        /// <summary>
        /// 将查询出的检测记录转为实体类输出
        /// </summary>
        /// <param name="dataTable">分页类实例</param>
        /// <returns>实体类List</returns>
        public List<TestRecord> GetTestRecords(Pagination pagination)
        {
            var dataTable = testRecordDAO.SelectTestRecords(pagination.Skip, pagination.Take);
            
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

            return testRecordList;
        }

        /// <summary>
        /// 获取检测记录记录数
        /// </summary>
        /// <returns>记录数</returns>
        public int GetTestRecordCount()
        {
            return testRecordDAO.GetTestRecordsCount();
        }    
    }
}
