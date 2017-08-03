// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 车辆送修申请单查询对象
    /// </summary>
    public class ApplyForVehicleMaintenanceQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// CarInfoId
        /// </summary>
        public Guid? CarInfoId
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
        /// Status
        /// </summary>
        public int? Status
        {
            get; set;
        }
    }
}



