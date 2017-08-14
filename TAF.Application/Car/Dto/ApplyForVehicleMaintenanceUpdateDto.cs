// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceUpdateDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修单更新对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Car.Dto
{
    using System;

    /// <summary>
    /// 车辆送修单更新对象
    /// </summary>
    public class ApplyForVehicleMaintenanceUpdateDto
    {
        public Guid Id { get; set; }

        public int Status { get; set; }

        public decimal Total { get; set; }

        public List<ManHourListDto> ManHour { get; set; }

        public List<MaintenanceDeliveryListDto> Deliveries { get; set; }

        public List<ServicingMaterialListDto> Materials { get; set; }
    }
}