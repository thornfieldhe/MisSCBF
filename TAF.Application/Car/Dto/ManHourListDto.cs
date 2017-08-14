// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManHourListDto.cs" company=""  author="何翔华">
//
// </copyright>
// <summary>
//   工时费列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 工时费列表对象
    /// </summary>
    [AutoMap(typeof(ManHour))]
    public class ManHourListDto
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
        public Guid ApplyForVehicleMaintenanceId
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
        /// ManHourName
        /// </summary>
        public string ManHourName
        {
            get; set;
        }

        /// <summary>
        /// 部件Id
        /// </summary>
        public Guid PartId { get; set; }

        /// <summary>
        /// 工时Id
        /// </summary>
        public Guid ManHourId { get; set; }

        /// <summary>
        /// Hours1
        /// </summary>
        public decimal? Hours1
        {
            get; set;
        }

        /// <summary>
        /// Hours2
        /// </summary>
        public decimal? Hours2
        {
            get; set;
        }
    }
}



