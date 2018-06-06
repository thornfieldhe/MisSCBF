// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;
    using System.Collections.Generic;

    using Abp.AutoMapper;

    /// <summary>
    /// 采购阶段编辑对象
    /// </summary>
    [AutoMap(typeof(StageInfo))]
    public class StageInfoEditDto
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
        public int Category
        {
            get; set;
        }

        /// <summary>
        /// Company
        /// </summary>
        public Guid Company
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
        /// PurchaseId
        /// </summary>
        public Guid ProcurementPlanId
        {
            get; set;
        }

        public List<Guid> AttachmentIds { get; set; }

        public List<string> Attachments { get; set; }

        public List<Guid> Users { get; set; }


    }
}



