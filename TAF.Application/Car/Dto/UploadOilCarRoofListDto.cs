// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadOilCarRoofListDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   UploadOilCarRoofListDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(UploadOilCardRoof))]
    public class UploadOilCarRoofListDto
    {
        public Guid Id { get; set; }

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
        public string Date { get; set; }

        /// <summary>
        /// 加油量
        /// </summary>
        public decimal Amount { get; set; }
    }
}