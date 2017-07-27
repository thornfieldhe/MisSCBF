// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerBQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 实物油料加油审批单查询对象
    /// </summary>
    public class ApplicationForBunkerBQueryDto : PagedAndSortedResultRequestDto
    {

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
        public Guid? OctaneStoreId
        {
            get; set;
        }

        /// <summary>
        /// DriverId
        /// </summary>
        public Guid? DriverId
        {
            get; set;
        }

        /// <summary>
        /// CarCode
        /// </summary>
        public string CarCode
        {
            get; set;
        }

        /// <summary>
        /// DateFrom
        /// </summary>
        public DateTime? DateFrom
        {
            get; set;
        }

        /// <summary>
        /// DateTo
        /// </summary>
        public DateTime? DateTo
        {
            get; set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public int? Status
        {
            get; set;
        }
    }
}



