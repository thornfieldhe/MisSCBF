// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairCostListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 车辆维修审批单列表对象
    /// </summary>
    [AutoMap(typeof(RepairCost))]
    public class RepairCostListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
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
        public int Year
        {
            get; set;
        }        
        
        /// <summary>
        /// Cost
        /// </summary>
        public decimal Cost
        {
            get; set;
        }        
        
        /// <summary>
        /// ApplyForVehicleMaintenanceName
        /// </summary>
        public string ApplyForVehicleMaintenanceName
        {
            get; set;
        }    
    } 
}



