// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadOilCardRoof.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   UploadOilCardRoof
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;

    /// <summary>
    /// 加油卡凭证上传对象
    /// </summary>
    public class UploadOilCardRoof : TAFEntity
    {
        /// <summary>
        /// 加油月份
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// 加油卡号
        /// </summary>
        public string CarCode { get; set; }

        /// <summary>
        /// 加油金额
        /// </summary>
        public decimal AmountOfMoney { get; set; }

        /// <summary>
        /// 加油时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 加油量
        /// </summary>
        public decimal Amount { get; set; }
    }
}