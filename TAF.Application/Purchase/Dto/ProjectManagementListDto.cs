// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购过程管理列表对象
    /// </summary>
    [AutoMap(typeof(ProjectManagement))]
    public class ProjectManagementListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid PlanId
        {
            get; set;
        }

        /// <summary>
        /// 计划编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 计划名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 开工日期
        /// </summary>
        public string Date1
        {
            get; set;
        }

        /// <summary>
        /// 合同金额
        /// </summary>
        public string Price1
        {
            get; set;
        }

        /// <summary>
        /// 审定报价
        /// </summary>
        public string Price2
        {
            get; set;
        }
    }
}



