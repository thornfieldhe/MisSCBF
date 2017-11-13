// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购阶段列表对象
    /// </summary>
    [AutoMap(typeof(StageInfo))]
    public class StageInfoListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Category
        /// </summary>
        public int Category
        {
            get; set;
        }

        /// <summary>
        /// Company
        /// </summary>
        public string Company
        {
            get; set;
        }

        /// <summary>
        /// Cost
        /// </summary>
        public decimal Cost
        {
            get; set;
        }

        /// <summary>
        /// Status
        /// </summary>
        public int Status
        {
            get; set;
        }

        /// <summary>
        /// ProcurementPlanName
        /// </summary>
        public string ProcurementPlanName
        {
            get; set;
        }
    }
}



