// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 历史库存查询对象
    /// </summary>
    public class DateRangeQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// DateFrom
        /// </summary>
        public DateTime DateFrom
        {
            get; set;
        }

        /// <summary>
        /// DateTo
        /// </summary>
        public DateTime DateTo
        {
            get; set;
        }
    }
}



