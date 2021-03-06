﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 招标文件管理编辑对象
    /// </summary>
    [AutoMap(typeof(BiddingManagement))]
    public class BiddingManagementEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// PlanId
        /// </summary>
        public Guid PlanId
        {
            get; set;
        }

        /// <summary>
        /// HasPrint
        /// </summary>
        public int HasPrint
        {
            get; set;
        }

        /// <summary>
        /// BiddingAgencyId
        /// </summary>
        public Guid BiddingAgencyId
        {
            get; set;
        }

        /// <summary>
        /// 评审专家
        /// </summary>
        public Guid ExpertId { get; set; }

        /// <summary>
        /// 评审专家姓名
        /// </summary>
        public string ExpertName { get; set; }

        /// <summary>
        /// 主要标的内容
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// PlanDateEnd
        /// </summary>
        public string PlanDateEnd
        {
            get; set;
        }

        /// <summary>
        /// Total
        /// </summary>
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Schedule
        /// </summary>
        public int Schedule
        {
            get; set;
        }

        public List<CostListDto> CostList { get; set; }
        public List<TendererDto> Tenderers { get; set; }
    }
}



