// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarInfoEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆信息编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    using Abp.AutoMapper;

    /// <summary>
    /// 车辆信息编辑对象
    /// </summary>
    [AutoMap(typeof(CarInfo))]
    public class CarInfoEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

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
        /// Ylbh
        /// </summary>
        public Guid OctaneRatingId
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
        /// Jcgls
        /// </summary>
        public decimal Jcgls
        {
            get; set;
        }

        /// <summary>
        /// Zbsj
        /// </summary>
        public string Zbsj
        {
            get; set;
        }

        /// <summary>
        /// Clzk
        /// </summary>
        public Guid Clzk
        {
            get; set;
        }

        /// <summary>
        /// Zbzl
        /// </summary>
        public string Zbzl
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
        /// Yxxe
        /// </summary>
        public decimal Yxxe
        {
            get; set;
        }

        /// <summary>
        /// Driver
        /// </summary>
        public string Driver
        {
            get; set;
        }

        /// <summary>
        /// 夏季油耗
        /// </summary>
        public decimal OilWearSummer { get; set; }

        /// <summary>
        /// 冬季油耗
        /// </summary>
        public decimal OilWearWinter { get; set; }

    }
}



