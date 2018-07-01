// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarRepairTimeQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 车辆维修耗时管理查询对象
    /// </summary>
    public class CarRepairTimeQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// DateToFrom
        /// </summary>
        public DateTime DateFrom
        {
            get; set;
        }

        /// <summary>
        /// DateToTo
        /// </summary>
        public DateTime DateTo
        {
            get; set;
        }

    }
}



