// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOil.cs" company="" author="何翔华">
//   单车油料核算
// </copyright>
// <summary>
//   Summary
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// 单车油料核算
    /// </summary>
    public class CarOil : TAFEntity
    {
        /// <summary>
        /// 车辆Id
        /// </summary>
        public Guid CarInfoId { get; set; }

        /// <summary>
        /// Gets or sets the car info.
        /// </summary>
        public virtual CarInfo CarInfo { get; set; }

        /// <summary>
        /// 月末公里数
        /// </summary>
        public decimal Kilometres { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 剩余油量
        /// </summary>
        public decimal Amount { get; set; }

    }
}