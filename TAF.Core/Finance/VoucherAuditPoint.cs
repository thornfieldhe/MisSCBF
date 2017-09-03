// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditPoint.cs" company="">
//   
// </copyright>
// <summary>
//   凭证审核要点类型
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    /// <summary>
    /// 凭证审核要点类型
    /// </summary>
    public static class VoucherAuditPoint
    {
        /// <summary>
        /// 是
        /// </summary>
        public static int Yes => 0;

        /// <summary>
        /// 否
        /// </summary>
        public static int No => 1;

        /// <summary>
        /// 无此情况
        /// </summary>
        public static int Undefinition => 2;
    }
}