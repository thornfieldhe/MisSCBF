﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Entry.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Entry
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using SCBF.BaseInfo;
    using System;

    /// <summary>
    /// 入库
    /// </summary>
    public class Entry : TAFEntity
    {
        /// <summary>
        /// 产品Id
        /// </summary>
        public Guid ProductId
        {
            get; set;
        }

        public virtual Product Product
        {
            get; set;
        }

        /// <summary>
        /// 入库量
        /// </summary>
        public decimal Amount
        {
            get; set;
        }


        /// <summary>
        /// 金额
        /// </summary>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 入库单据Id
        /// </summary>
        public Guid EntryBillId
        {
            get; set;
        }

        public virtual EntryBill EntryBill
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public Guid StorageId
        {
            get; set;
        }

        public virtual SysDictionary Storage
        {
            get; set;
        }

    }
}