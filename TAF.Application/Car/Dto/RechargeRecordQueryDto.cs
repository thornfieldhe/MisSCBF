// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RechargeRecordQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 油料分配记录查询对象
    /// </summary>
    public class RechargeRecordQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// OilCardId
        /// </summary>
        public Guid? OilCardId
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
    }
}



