// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 油料卡编辑对象
    /// </summary>
    [AutoMap(typeof(OilCard))]
    public class OilCardEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// CarInfoId
        /// </summary>
        public Guid CarInfoId
        {
            get; set;
        }
    }
}



