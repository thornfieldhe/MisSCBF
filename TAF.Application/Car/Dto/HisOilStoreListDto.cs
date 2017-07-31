// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisOilStoreListDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   HisOilStoreListDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    /// <summary>
    /// 季度油料消耗列表数据
    /// </summary>
    public class HisOilStoreListDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 期初升数
        /// </summary>
        public decimal FromAmount { get; set; }

        /// <summary>
        /// 期末升数
        /// </summary>
        public decimal ToAmount { get; set; }

        /// <summary>
        /// 消耗升数
        /// </summary>
        public decimal UseAmount => FromAmount - ToAmount;

        /// <summary>
        /// 期初顿数
        /// </summary>
        public decimal FromAmountAsT { get; set; }

        /// <summary>
        /// 期末顿数
        /// </summary>
        public decimal ToAmountAsT { get; set; }

        /// <summary>
        /// 消耗吨数
        /// </summary>
        public decimal UseAmountAsT => FromAmountAsT - ToAmountAsT;
    }
}