// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditManagementDto.cs" company=""  author="何翔华">
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
    [AutoMap(typeof(AuditManagement))]
    public class AuditManagementDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// ProjectId
        /// </summary>
        public Guid ProjectId
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
        /// Price
        /// </summary>
        public decimal Price
        {
            get; set;
        }
    }
}



