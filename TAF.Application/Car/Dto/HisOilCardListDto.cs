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
    public class HisOilCardListDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// 期初数
        /// </summary>
        public decimal FromAmount { get; set; }

        /// <summary>
        /// 期末数
        /// </summary>
        public decimal ToAmount { get; set; }

        /// <summary>
        /// 消耗数
        /// </summary>
        public decimal UseAmount => FromAmount - ToAmount;
    }
}