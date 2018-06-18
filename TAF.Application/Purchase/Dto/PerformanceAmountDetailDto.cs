// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceAmountDetailDto.cs" company=""  author="何翔华">
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
    [AutoMap(typeof(PerformanceAmountDetail))]
    public class PerformanceAmountDetailDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
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
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// PerformanceManageId
        /// </summary>
        public Guid PerformanceManageId
        {
            get; set;
        }

        /// <summary>
        /// User
        /// </summary>
        public string User
        {
            get; set;
        }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone
        {
            get; set;
        }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// EditStatus
        /// </summary>
        public bool EditStatus { get; set; }
    }
}



