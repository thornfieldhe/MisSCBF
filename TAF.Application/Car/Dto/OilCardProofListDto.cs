// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardProofListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 加油卡消耗凭证单列表对象
    /// </summary>
    [AutoMap(typeof(OilCardProof))]
    public class OilCardProofListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// 月份
        /// </summary>
        public string Month
        {
            get; set;
        }

        /// <summary>
        /// 加油凭证单号
        /// </summary>
        public string BunkerACode
        {
            get; set;
        }

        /// <summary>
        /// 加油时间
        /// </summary>
        public string Date
        {
            get; set;
        }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo
        {
            get; set;
        }

        /// <summary>
        /// 车辆牌号
        /// </summary>
        public string CarCode
        {
            get; set;
        }

        /// <summary>
        /// 车辆型号
        /// </summary>
        public string Clxh
        {
            get; set;
        }

        /// <summary>
        /// 原有金额
        /// </summary>
        public decimal Yyje
        {
            get; set;
        }

        /// <summary>
        /// 加油金额
        /// </summary>
        public decimal Jyje
        {
            get; set;
        }

        /// <summary>
        /// 剩余金额
        /// </summary>
        public decimal Syje
        {
            get; set;
        }

        /// <summary>
        /// 油料编号
        /// </summary>
        public string Ylbh
        {
            get; set;
        }

        /// <summary>
        /// 加油升数
        /// </summary>
        public decimal Jysh
        {
            get; set;
        }

        /// <summary>
        /// 每升价格
        /// </summary>
        public decimal Msjg
        {
            get; set;
        }

        /// <summary>
        /// 驾驶员
        /// </summary>
        public string Jsy
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// 事由
        /// </summary>
        public string Sy
        {
            get; set;
        }
    }
}



