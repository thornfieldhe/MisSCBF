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

        public List<ManHourListDto> ManHours { get; set; }

        public List<MaintenanceDeliveryListDto> MaintenanceDeliveries { get; set; }

        public List<ServicingMaterialListDto> ServicingMaterials { get; set; }
    }
}