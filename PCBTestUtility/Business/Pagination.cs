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

using System.Linq;

namespace Microstar.Production.PCBTest.Business
{
    /// <summary>
    /// 分页类
    /// </summary>
    public sealed class Pagination
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Skip { get; private set; }

        /// <summary>
        /// 该页显示的记录数
        /// </summary>
        public int Take { get; private set; }

        /// <summary>
        /// 用于返回总记录数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 初始化属性
        /// </summary>
        /// <param name="skip">页码</param>
        /// <param name="take">该页显示的记录数</param>
        public Pagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        /// <summary>
        /// 初始化属性
        /// </summary>
        /// <param name="skip">页码</param>
        /// <param name="take">该页显示的记录数</param>
        /// <param name="count">总记录数</param>
        public Pagination(int skip, int take, int count)
        {
            Skip = skip;
            Take = take;
            Count = count;
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="current">当前页信息</param>
        /// <returns>下一页信息</returns>
        Pagination GetNextPage(Pagination current)
        {
            int skip = current.Skip * current.Take;
            int take = current.Take;
            int count = current.Count;

            return new Pagination(skip, take, count);
        }
    }
}
