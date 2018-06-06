// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 投标过程管理列表对象
    /// </summary>
    [AutoMap(typeof(ProcessManagement))]
    public class ProcessManagementListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Users
        /// </summary>
        public string Users
        {
            get; set;
        }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName
        {
            get; set;
        }

        /// <summary>
        /// 进度
        /// </summary>
        public decimal Schedule
        {
            get; set;
        }

        /// <summary>
        /// 采购项目名称
        /// </summary>
        public string PurchaseName { get; set; }


        /// <summary>
        /// PurchaseId
        /// </summary>
        public Guid PurchaseId { get; set; }
    }
}



