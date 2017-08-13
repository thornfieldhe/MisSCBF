// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerBListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 实物油料加油审批单列表对象
    /// </summary>
    [AutoMap(typeof(ApplicationForBunkerB))]
    public class ApplicationForBunkerBListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// OctaneStoreName
        /// </summary>
        public string OctaneStoreName
        {
            get; set;
        }

        /// <summary>
        /// 号牌
        /// </summary>
        public string CarCode
        {
            get; set;
        }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string CarSpecifications
        {
            get; set;
        }

        /// <summary>
        /// OctaneStoreId
        /// </summary>
        public Guid OctaneStoreId
        {
            get; set;
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// TotalAmount
        /// </summary>
        public decimal TotalAmount
        {
            get; set;
        }

        /// <summary>
        /// AuditingAmount
        /// </summary>
        public decimal AuditingAmount
        {
            get; set;
        }

        /// <summary>
        /// DriverName
        /// </summary>
        public string DriverName
        {
            get; set;
        }

        /// <summary>
        /// AuditorName
        /// </summary>
        public string AuditorName
        {
            get; set;
        }

        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public string Status
        {
            get; set;
        }

        /// <summary>
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

        public decimal? AmountFrom { get; set; }


        public decimal? AmountTo { get; set; }

        public decimal? ChangedAmount { get; set; }
    }
}



