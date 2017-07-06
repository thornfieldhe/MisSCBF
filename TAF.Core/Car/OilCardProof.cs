// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardProof.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   OilCardProof
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 加油卡消耗凭证
    /// </summary>
    public class OilCardProof : TAFEntity
    {
        /// <summary>
        /// 凭证生成月份,显示:yyyyMM
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// 加油卡加油审批单号
        /// </summary>
        public string BunkerACode { get; set; }

        /// <summary>
        /// 加油时间
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 升数
        /// </summary>
        public decimal Ss { get; set; }

        /// <summary>
        /// 每升价格
        /// </summary>
        public decimal Msjg { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 车辆型号
        /// </summary>
        public string Clxh { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string Cph { get; set; }

        /// <summary>
        /// 加油事由
        /// </summary>
        public string Sy { get; set; }

        /// <summary>
        /// 原有金额
        /// </summary>
        public decimal Yyje { get; set; }

        /// <summary>
        /// 加油金额
        /// </summary>
        public decimal Jyje { get; set; }

        /// <summary>
        /// 剩余金额
        /// </summary>
        public decimal Syje { get; set; }

        /// <summary>
        /// 油料标号
        /// </summary>
        public string Ylbh { get; set; }

        /// <summary>
        /// 驾驶员
        /// </summary>
        public string Jsy { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

    }
}