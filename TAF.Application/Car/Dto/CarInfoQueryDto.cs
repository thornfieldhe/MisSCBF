// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarInfoQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆信息查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 车辆信息查询对象
    /// </summary>
    public class CarInfoQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// Clxh
        /// </summary>
        public string Clxh
        {
            get; set;
        }

        /// <summary>
        /// Cjh
        /// </summary>
        public string Cjh
        {
            get; set;
        }

        /// <summary>
        /// Fdjh
        /// </summary>
        public string Fdjh
        {
            get; set;
        }

        /// <summary>
        /// Cph
        /// </summary>
        public string Cph
        {
            get; set;
        }

        /// <summary>
        /// ZbsjFrom
        /// </summary>
        public DateTime? ZbsjFrom
        {
            get; set;
        }

        /// <summary>
        /// ZbsjTo
        /// </summary>
        public DateTime? ZbsjTo
        {
            get; set;
        }

        /// <summary>
        /// Clzk
        /// </summary>
        public Guid? Clzk
        {
            get; set;
        }

        /// <summary>
        /// Xszh
        /// </summary>
        public string Xszh
        {
            get; set;
        }

        /// <summary>
        /// Driver
        /// </summary>
        public Guid? Driver
        {
            get; set;
        }
    }
}



