// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerAListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 加油卡申请加油审批单列表对象
    /// </summary>
    [AutoMap(typeof(ApplicationForBunkerA))]
    public class ApplicationForBunkerAListDto
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
        /// OilCardName
        /// </summary>
        public string OilCardName
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
    }
}



