// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 支出预算列表对象
    /// </summary>
    [AutoMap(typeof(BudgetOutlay))]
    public class BudgetOutlayListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
        /// Year
        /// </summary>
        public int Year
        {
            get; set;
        }

        /// <summary>
        /// FileId
        /// </summary>
        public string FileId
        {
            get; set;
        }

        /// <summary>
        /// SheetName
        /// </summary>
        public string SheetName
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
        /// HasRelated
        /// </summary>
        public bool HasRelated
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
        /// Column1
        /// </summary>
        public decimal Column1
        {
            get; set;
        }

        /// <summary>
        /// Column2
        /// </summary>
        public decimal Column2
        {
            get; set;
        }

        /// <summary>
        /// Column3
        /// </summary>
        public decimal Column3
        {
            get; set;
        }

        /// <summary>
        /// Total1
        /// </summary>
        public decimal Total1
        {
            get; set;
        }

        /// <summary>
        /// Total2
        /// </summary>
        public decimal Total2
        {
            get; set;
        }

        /// <summary>
        /// Total3
        /// </summary>
        public decimal Total3
        {
            get; set;
        }
    }
}



