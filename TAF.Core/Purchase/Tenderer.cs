// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tenderer.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标人管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 投标人管理
    /// </summary>
    public class Tenderer: TAFEntity
    {
        /// <summary>
        /// 招标书Id
        /// </summary>
        public Guid BiddingManagementId { get; set; }

        /// <summary>
        /// 投标单位名称
        /// </summary>
        public string Name { get; set; }
    }
}
