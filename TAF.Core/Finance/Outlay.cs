// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Outlay.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Outlay
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    /// <summary>
    /// 结余表
    /// </summary>
    public class Outlay : TAFEntity
    {
        public int Year { get; set; }

        /// <summary>
        /// 实际科目结余
        /// </summary>
        public decimal Total1 { get; set; }

        /// <summary>
        /// 家底
        /// </summary>
        public decimal Total2 { get; set; }

        /// <summary>
        /// 下年
        /// </summary>
        public decimal Total3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 财务代码
        /// </summary>
        public string Code { get; set; }
    }
}