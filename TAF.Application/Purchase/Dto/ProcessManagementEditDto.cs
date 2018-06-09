// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 投标过程管理编辑对象
    /// </summary>
    [AutoMap(typeof(ProcessManagement))]
    public class ProcessManagementEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid PurchaseId
        {
            get; set;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get; set;
        }

        /// <summary>
        /// Unit
        /// </summary>
        public Guid Unit
        {
            get; set;
        }

        /// <summary>
        /// Unit
        /// </summary>
        public string UnitName
        {
            get; set;
        }

        /// <summary>
        /// 采购人员
        /// </summary>
        public List<Guid> Users { get; set; }

        public int Status { get; set; }

        public decimal Schedule { get; set; }

        public decimal Price { get; set; }
    }
}



