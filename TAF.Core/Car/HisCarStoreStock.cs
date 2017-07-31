// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreStock.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   OctaneStoreStock
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 实物油料/加油卡库存
    /// </summary>
    public class HisCarStoreStock : TAFEntity
    {
        public Guid OctaneStoreId { get; set; }

        public decimal Amount { get; set; }

        public string YearMonth { get; set; }

        public int Category { get; set; }
    }
}