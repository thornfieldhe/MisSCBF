// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStore.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   OctaneStore
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 实物油料库
    /// </summary>
    public class OctaneStore : TAFEntity
    {
        /// <summary>
        /// 代管单位
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// 油料标号
        /// </summary>
        public Guid OctaneRatingId { get; set; }
    }
}