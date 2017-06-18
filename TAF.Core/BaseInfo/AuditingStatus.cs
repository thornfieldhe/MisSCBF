// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditingStatus.cs" company="">
//   ÉóºË×´Ì¬
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
        /// µÈ´ýÉóºË
        /// </summary>
        Pending = 0,

        /// <summary>
        /// ÉóºËÍ¨¹ý
        /// </summary>
        Approved = 1,

        /// <summary>
        /// ÉóºË¾Ü¾ø
        /// </summary>
        Refused = 2
    }
}