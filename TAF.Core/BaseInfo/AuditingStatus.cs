// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditingStatus.cs" company="">
//   审核状态
// </copyright>
// <summary>
//   Defines the AuditingStatus type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    public enum AuditingStatus
    {
        /// <summary>
        /// 等待审核
        /// </summary>
        Pending = 0,

        /// <summary>
        /// 审核通过
        /// </summary>
        Approved = 1,

        /// <summary>
        /// 审核拒绝
        /// </summary>
        Refused = 2
    }

    /// <summary>
    /// 加油卡审批状态
    /// </summary>
    public static class ApplicationForBunkerAStatus
    {
        public static int Pending => 0;

        public static int Approved => 1;

        public static int Refused => 2;

        public static int Confirm => 3; //金额确认

        public static int Cancel => 4; //作废
    }

    /// <summary>
    /// 加油卡审批状态
    /// </summary>
    public static class ProofStatus
    {
        public static int Success => 0;

        public static int NoProof => 1; // 无消耗凭证

        public static int NoBunker => 2; // 无审批单
    }
}