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

    /// <summary>
    /// 采购过程管理编辑对象
    /// </summary>
    public class ProjectManagementPriceDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Price1
        /// </summary>
        public decimal Price1
        {
            get; set;
        }

        /// <summary>
        /// Price2
        /// </summary>
        public decimal Price2
        {
            get; set;
        }

        /// <summary>
        /// Price3
        /// </summary>
        public decimal Price3
        {
            get; set;
        }


    }
}



