// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerBEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 实物油料加油审批单编辑对象
    /// </summary>
    [AutoMap(typeof(ApplicationForBunkerB))]
    public class ApplicationForBunkerBEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
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
        /// OctaneStoreId
        /// </summary>
        public Guid OctaneStoreId
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


        public Guid CarInfoId { get; set; }


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
        /// DriverId
        /// </summary>
        public Guid DriverId
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
        /// AuditorId
        /// </summary>
        public Guid? AuditorId
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
        public int Status
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



