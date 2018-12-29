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

using Microstar.Production.Tools;
using System.Data;
using System.Data.SqlClient;
using Microstar.Production.PCBTest.Model;
using System;

namespace Microstar.Production.PCBTest.DAL
{
    /// <summary>
    /// 用户信息数据库操作
    /// </summary>
    public sealed class UserDAO
    {
        private static Lazy<UserDAO> instance = new Lazy<UserDAO>(() => new UserDAO());

        /// <summary>
        /// 获取UserDAO实例
        /// </summary>
        public static UserDAO Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// 防止直接调用构造函数
        /// </summary>
        private UserDAO()
        { }

        /// <summary>
        /// 根据用户名找检测员工号
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>员工号</returns>
        public User GetUserByName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Username can't be empty or null.");
            }

            string sql = "select * from Users where user_name = @username";
            SqlParameter paraUserName = new SqlParameter("@username", userName);
            DataTable table = SqlHelper.ExecuteDataTable(sql, paraUserName);

            //数据库中未找到该用户
            if (table.Rows.Count == 0)
            {
                return null;
            }

            User user = new User();

            user.Number = (int)table.Rows[0]["number"];
            user.UserName = table.Rows[0]["user_name"].ToString();
            user.Password = table.Rows[0]["password"].ToString();
            user.Name = table.Rows[0]["name"].ToString();

            return user;
        }
    }
}
