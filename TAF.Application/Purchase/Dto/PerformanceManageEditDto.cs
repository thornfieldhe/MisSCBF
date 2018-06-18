// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceManageEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 履约保证金管理编辑对象
    /// </summary>
    [AutoMap(typeof(PerformanceManage))]
    public class PerformanceManageEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// PlanId
        /// </summary>
        public Guid PlanId
        {
            get; set;
        }

        /// <summary>
        /// HasPrint
        /// </summary>
        public int HasPrint
        {
            get; set;
        }

        /// <summary>
        /// MarginAmount
        /// </summary>
        public decimal MarginAmount
        {
            get; set;
        }

        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }
    }
}



