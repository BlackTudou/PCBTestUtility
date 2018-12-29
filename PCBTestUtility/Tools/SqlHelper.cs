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

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Microstar.Production.Tools
{
    /// <summary>
    /// 数据库操作帮助类
    /// </summary>
    public static class SqlHelper
    {
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns>数据库连接字符串</returns>
        public static string GetSqlConnectionStrings()
        {
            return ConfigurationManager.ConnectionStrings["Microstar.Production.PCBTest.Properties.Settings.PCBTestUtilityDBConnStr"].ConnectionString;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">需要执行的sql脚本</param>
        /// <param name="parameters">可变长度参数Parameter</param>
        /// <returns>表中受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetSqlConnectionStrings()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery(); //执行命令
                }
            }
        }

        /// <summary>
        /// 查询语句 
        /// </summary>
        /// <param name="sql">需要执行的sql脚本</param>
        /// <param name="parameters">需要的参数集合</param>
        /// <returns>查询结果中的第一行第一列的值</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            //先建立连接
            using (SqlConnection conn = new SqlConnection(GetSqlConnectionStrings()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open(); //打开连接
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询数据，dt将被填充查询出来的数据，然后返回数据
        /// </summary>
        /// <param name="sql">需要执行的sql脚本</param>
        /// <param name="parameters">需要的参数集合</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, GetSqlConnectionStrings())) //数据适配器
            {
                using (DataTable dt = new DataTable())
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters);
                    adapter.Fill(dt); //填充数据到DataTable
                    return dt;
                }
            }
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">需要执行的sql脚本</param>
        /// <param name="parameters">需要的参数集合</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            //SqlDataReader要求，它读取数据的时候有，它独占它的SqlConnection对象，而且SqlConnection必须是Open状态
            using (SqlConnection conn = new SqlConnection(GetSqlConnectionStrings()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, GetSqlConnectionStrings())) //数据适配器
            {
                using (DataTable dataTable = new DataTable())
                {
                    dataTable.Clear();
                    adapter.Fill(dataTable); //填充数据到DataTable
                    return dataTable;
                }
            }
        }
    }
}
