namespace SCBF.Purchase
{
    /// <summary>
    /// 招标类型
    /// </summary>
    public static class BiddingType
    {
        /// <summary>
        /// 邀请招标
        /// </summary>
        public static string Yqzb { get; set; }

        /// <summary>
        /// 竞争性谈判
        /// </summary>
        public static string Jzxtp { get; set; }

        /// <summary>
        /// 询价采购
        /// </summary>
        public static string Xjcg { get; set; }

        /// <summary>
        /// 比选采购
        /// </summary>
        public static string Bxcg { get; set; }

        /// <summary>
        /// 公开招标(最低价法)
        /// </summary>
        public static string GkzbZdjf { get; set; }

        /// <summary>
        /// 公开招标(综合评分法)
        /// </summary>
        public static string GkzbZhpff { get; set; }

        /// <summary>
        /// 单一来源采购
        /// </summary>
        public static string Dylycg { get; set; }
    }
}