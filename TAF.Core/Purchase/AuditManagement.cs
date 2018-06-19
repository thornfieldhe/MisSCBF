// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditManagement.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目审计表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 项目审计表
    /// </summary>
    public class AuditManagement: TAFEntity
    {
        /// <summary>
        /// 项目Id
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// 审计说明
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 审计金额
        /// </summary>
        public decimal Price { get; set; }
    }
}
