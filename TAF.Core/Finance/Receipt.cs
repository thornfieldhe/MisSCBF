// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Receipt.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Receipt
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System.Collections.Generic;

    /// <summary>
    /// 收入汇总表
    /// </summary>
    public class Receipt : TAFEntity
    {
        public int Year { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        /// 财务代码
        /// </summary>
        public string Code { get; set; }



    }
}