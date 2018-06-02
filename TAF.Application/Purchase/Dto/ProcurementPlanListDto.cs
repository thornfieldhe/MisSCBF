// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购计划列表对象
    /// </summary>
    [AutoMap(typeof(ProcurementPlan))]
    public class ProcurementPlanListDto
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
        public string Department
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
    }
}



