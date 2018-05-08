// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlaySimpleListDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   BudgetOutlaySimpleListDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(BudgetOutlay))]
    public class BudgetOutlaySimpleListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
        /// Amount
        /// </summary>
        public decimal Amount
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

        /// <summary>
        /// Unit
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// Unit
        /// </summary>
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// 未关联金额
        /// </summary>
        public decimal UnUsed
        {
            get; set;
        }
    }
}