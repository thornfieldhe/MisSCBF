namespace SCBF.Purchase
{
    /// <summary>
    /// 过程状态
    /// </summary>
    public enum ProcessStatus
    {
        /// <summary>
        /// 新建
        /// </summary>
        Created =0,

        /// <summary>
        /// 已打印合同
        /// </summary>
        NoticePrinted =1,

        /// <summary>
        /// 已填写费用
        /// </summary>
        AmountDetermined =2
    }
}