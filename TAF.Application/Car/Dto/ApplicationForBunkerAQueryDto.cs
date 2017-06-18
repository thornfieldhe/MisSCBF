// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerAQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 加油卡申请加油审批单查询对象
    /// </summary>
    public class ApplicationForBunkerAQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// OilCardId
        /// </summary>
        public Guid? OilCardId
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



