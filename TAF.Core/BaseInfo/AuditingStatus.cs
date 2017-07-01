// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditingStatus.cs" company="">
//   ���״̬
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
        /// �ȴ����
        /// </summary>
        Pending = 0,

        /// <summary>
        /// ���ͨ��
        /// </summary>
        Approved = 1,

        /// <summary>
        /// ��˾ܾ�
        /// </summary>
        Refused = 2
    }

    /// <summary>
    /// ���Ϳ�����״̬
    /// </summary>
    public static class ApplicationForBunkerAStatus
    {
        public static int Pending => 0;

        public static int Approved => 1;

        public static int Refused => 2;

        public static int Confirm => 3; //���ȷ��
    }
}