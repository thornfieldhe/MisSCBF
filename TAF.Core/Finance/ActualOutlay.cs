// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlay.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ActualOutlay
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 实际支出表
    /// </summary>
    public class ActualOutlay : TAFEntity
    {
        /// <summary>
        /// 凭证号
        /// </summary>
        public string VoucherNo
        {
            get; set;
        }

        /// <summary>
        /// 凭证发生时间
        /// </summary>
        public DateTime Date
        {
            get; set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Note
        {
            get; set;
        }

        public Guid? OutlayId { get; set; }

        /// <summary>
        /// 预算支出
        /// </summary>
        public virtual BudgetOutlay Outlay { get; set; }

        /// <summary>
        /// 同一批次导入的预算文件的文件Id保持一致
        /// </summary>
        public Guid FileId
        {
            get; set;
        }

        public int Year { get; set; }
        
    }
}