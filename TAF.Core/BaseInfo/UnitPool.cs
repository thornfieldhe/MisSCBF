// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPool.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   对象池
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;

    /// <summary>
    /// 对象池
    /// </summary>
    public class UnitPool: TAFEntity
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 成员Id
        /// </summary>
        public Guid ItemId { get; set; }
    }
}
