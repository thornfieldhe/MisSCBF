// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqManager.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   质量评价管理
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 质量评价管理
    /// </summary>
    public class EqManager: TAFEntity
    {
        public Guid PlanId { get; set; }

        /// <summary>
        /// 招标代理单位
        /// </summary>
        public Guid? Unit1 { get; set; }

        /// <summary>
        /// 招标代理单位评分
        /// </summary>
        public decimal? Score1 { get; set; }

        /// <summary>
        /// 监理单位
        /// </summary>
        public Guid? Unit2 { get; set; }

        /// <summary>
        /// 监理单位评分
        /// </summary>
        public decimal? Score2 { get; set; }

        /// <summary>
        /// 造价单位
        /// </summary>
        public Guid? Unit3 { get; set; }

        /// <summary>
        /// 造价单位评分
        /// </summary>
        public decimal? Score3 { get; set; }

        /// <summary>
        /// 设计单位
        /// </summary>
        public Guid? Unit4 { get; set; }

        /// <summary>
        /// 设计单位评分
        /// </summary>
        public decimal? Score4 { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string Unit5 { get; set; }

        /// <summary>
        /// 供应商评分
        /// </summary>
        public decimal? Score5 { get; set; }

    }
}
