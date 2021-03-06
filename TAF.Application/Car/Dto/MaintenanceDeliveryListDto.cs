﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaintenanceDeliveryListDto.cs" company=""  author="何翔华">
//
// </copyright>
// <summary>
//   自有材料领用列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 自有材料领用列表对象
    /// </summary>
    [AutoMap(typeof(MaintenanceDelivery))]
    public class MaintenanceDeliveryListDto
    {
        /// <summary>
        /// ApplyForVehicleMaintenanceId
        /// </summary>
        public Guid? ApplyForVehicleMaintenanceId
        {
            get; set;
        }

        /// <summary>
        /// DeliveryId
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// ProductName
        /// </summary>
        public string Name
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
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }
    }
}



