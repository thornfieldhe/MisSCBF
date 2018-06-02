// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SCBF.Finance;

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购计划编辑对象
    /// </summary>
    [AutoMap(typeof(ProcurementPlan))]
    public class ProcurementPlanEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// Mode
        /// </summary>
        public string Mode
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
        /// Name
        /// </summary>
        public string Name
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

        /// <summary>
        /// Department
        /// </summary>
        public Guid Department
        {
            get; set;
        }

        /// <summary>
        /// User
        /// </summary>
        public Guid User
        {
            get; set;
        }


        /// <summary>
        /// 关联的预算计划类型
        /// </summary>
        public BungetType Type { get; set; }
    }
}



