// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairCostEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 车辆维修审批单编辑对象
    /// </summary>
    [AutoMap(typeof(RepairCost))]
    public class RepairCostEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
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
        /// ApplyForVehicleMaintenanceId
        /// </summary>
        public Guid ApplyForVehicleMaintenanceId
        {
            get; set;
        }        
    } 
}



