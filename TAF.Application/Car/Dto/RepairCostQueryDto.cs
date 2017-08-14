// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairCostQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 车辆维修审批单查询对象
    /// </summary>
    public class RepairCostQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }        
        
        /// <summary>
        /// Year
        /// </summary>
        public int? Year
        {
            get; set;
        }        
        
        /// <summary>
        /// Cost
        /// </summary>
        public decimal? Cost
        {
            get; set;
        }        
        
        /// <summary>
        /// ApplyForVehicleMaintenanceId
        /// </summary>
        public Guid? ApplyForVehicleMaintenanceId
        {
            get; set;
        }        
    } 
}



