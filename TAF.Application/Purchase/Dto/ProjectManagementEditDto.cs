// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购过程管理编辑对象
    /// </summary>
    [AutoMap(typeof(ProjectManagement))]
    public class ProjectManagementEditDto
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
        /// Date1
        /// </summary>
        public string Date1
        {
            get; set;
        }

        /// <summary>
        /// Date2
        /// </summary>
        public string Date2
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

    }
}



