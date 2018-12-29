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

using Microstar.Production.PCBTest.Model;
using Microstar.Production.Tools;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Microstar.Production.PCBTest.DAL
{
    /// <summary>
    /// 检测记录数据库操作
    /// </summary>
    public sealed class TestRecordDAO
    {
        private static Lazy<TestRecordDAO> intance = new Lazy<TestRecordDAO>(() => new TestRecordDAO());
        public static readonly string tableName = "TestInformation";

        /// <summary>
        /// 获取TestRecordDAO实例
        /// </summary>
        public static TestRecordDAO Instance
        {
            get
            {
                return intance.Value;
            }
        }

        /// <summary>
        /// 防止直接调用构造函数
        /// </summary>
        private TestRecordDAO()
        { }

        /// <summary>
        /// 插入检测结果信息数据到数据库
        /// </summary>
        /// <param name="information">要插入到数据库的数据</param>
        /// <returns>表中受影响的行数</returns>
        public int InsertTestRecord(TestRecord information)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@meter_number", information.MeterNumber),
                new SqlParameter("@inspector_number", information.InspectorNumber),
                new SqlParameter("@customer_code", information.CustomerCode),
                new SqlParameter("@test_time", information.Time),
                new SqlParameter("@test_items", information.Items),
                new SqlParameter("@test_result", information.Result),
                new SqlParameter("@detail_info", information.DetailedInformation)
            };

            string sql = "insert into TestInformation(meter_number, inspector_number, customer_code, test_time, test_items, test_result, detail_info) " +
                "values(@meter_number, @inspector_number, @customer_code, @test_time, @test_items, @test_result, @detail_info)";

            return SqlHelper.ExecuteNonQuery(sql, sqlParameters);
        }

        /// <summary>
        /// 查询检测记录
        /// </summary>
        /// <param name="pageIndex">查询页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns>检测记录</returns>
        public DataTable SelectTestRecords(int pageIndex, int pageSize)
        {
            if (pageIndex < 0 || pageSize < 0)
            {
                throw new ArgumentException("Page index or page size can't be less than zero.");
            }

            string sqlString = @"select *
                                from (select *, ROW_NUMBER() over (order by ID) AS RowNumber
                                      from TestInformation
                                      where 1 = 1) T
                                where RowNumber between @skip and @end
                                order by ID";

            int skip = (pageIndex - 1) * pageSize + 1; //记录的开始下标
            int end = pageIndex * pageSize; //记录的结束下标

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@skip",skip),
                new SqlParameter("@end",end)
            };

            var dataTable = SqlHelper.ExecuteDataTable(sqlString, parameters);

            return dataTable;
        }

        /// <summary>
        /// 获取检测记录数据库中 记录数
        /// </summary>
        /// <returns>记录数</returns>
        public int GetTestRecordsCount()
        {
            string sqlString = string.Format("select count(*) from {0}", tableName);

            using (DataTable table = SqlHelper.ExecuteDataTable(sqlString))
            {          
                return  (int)table.Rows[0][0];
            }
        }
    }
}
