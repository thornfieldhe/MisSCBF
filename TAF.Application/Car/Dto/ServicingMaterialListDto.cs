// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicingMaterialListDto.cs" company=""  author="何翔华">
//
// </copyright>
// <summary>
//   维修材料列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 维修材料列表对象
    /// </summary>
    [AutoMap(typeof(ServicingMaterial))]
    public class ServicingMaterialListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? RowId
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

        /// <summary>
        /// PartName
        /// </summary>
        public string PartName
        {
            get; set;
        }

        /// <summary>
        /// MaterialName
        /// </summary>
        public string MaterialName
        {
            get; set;
        }

        /// <summary>
        /// 部件Id
        /// </summary>
        public Guid PartId { get; set; }

        /// <summary>
        /// 材料Id
        /// </summary>
        public Guid MaterialId { get; set; }

        /// <summary>
        /// Amount1
        /// </summary>
        public decimal Amount1
        {
            get; set;
        }

        /// <summary>
        /// Amount2
        /// </summary>
        public decimal? Amount2
        {
            get; set;
        }

        public decimal MaterialValue { get; set; }
    }
}



