// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaintenanceDeliveryListDto.cs" company=""  author="何翔华">
//
// </copyright>
// <summary>
//   自有材料领用列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 自有材料领用列表对象
    /// </summary>
    [AutoMap(typeof(MaintenanceDelivery))]
    public class MaintenanceDeliveryListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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

        /// <summary>
        /// DeliveryId
        /// </summary>
        public Guid DeliveryId
        {
            get; set;
        }

        /// <summary>
        /// ProductName
        /// </summary>
        public string ProductName
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
        /// 金额
        /// </summary>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Total
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
        /// Unit
        /// </summary>
        public string Unit
        {
            get; set;
        }
    }
}



