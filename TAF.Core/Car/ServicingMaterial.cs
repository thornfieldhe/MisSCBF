// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicingMaterial.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   维修材料
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 维修材料
    /// </summary>
    public class ServicingMaterial : TAFEntity
    {
        /// <summary>
        /// 维修单据Id
        /// </summary>
        public Guid ApplyForVehicleMaintenanceId { get; set; }

        public virtual ApplyForVehicleMaintenance ApplyForVehicleMaintenance { get; set; }

        /// <summary>
        /// 部件Id
        /// </summary>
        public Guid PartId { get; set; }

        /// <summary>
        /// 材料Id
        /// </summary>
        public Guid MaterialId { get; set; }

        /// <summary>
        /// 预算消耗量
        /// </summary>
        public decimal Amount1 { get; set; }

        /// <summary>
        /// 结算消耗量
        /// </summary>
        public decimal Amount2 { get; set; }
    }
}