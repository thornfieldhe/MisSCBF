// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   HisStockDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class HisStockDto
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 类型 0:加油卡,1:实物油料
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        public string YearMonth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }
    }
}