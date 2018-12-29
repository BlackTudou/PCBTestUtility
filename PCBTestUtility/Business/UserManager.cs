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

using System;
using Microstar.Production.PCBTest.DAL;
using Microstar.Production.PCBTest.Model;
using Microstar.Production.PCBTest.Properties;

namespace Microstar.Production.PCBTest.Business
{
    /// <summary>
    /// 用户处理业务层
    /// </summary>
    public sealed class UserManager
    {
        private static Lazy<UserManager> instance = new Lazy<UserManager>(() => new UserManager());
        private UserDAO userDAO = UserDAO.Instance;

        /// <summary>
        /// 防止直接调用构造函数
        /// </summary>
        private UserManager()
        { }

        /// <summary>
        /// 获取UserManager实例
        /// </summary>
        public static UserManager Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// 根据用户名找检测员工号
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>员工号</returns>
        public User SelectUserNumber(string userName)
        {
            return userDAO.GetUserByName(userName);
        }

        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>失败返回null，成功返回实例</returns>
        public User Login(string userName, string password)
        {
            var user = userDAO.GetUserByName(userName);
            if (user == null)
            {
                return null;
            }

            if (user.Password != password)
            {
                return null;
            }
            return user;
        }
    }
}
