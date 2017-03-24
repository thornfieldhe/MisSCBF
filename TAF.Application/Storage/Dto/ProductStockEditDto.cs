// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    /// <summary>
    /// 出入库编辑对象
    /// </summary>
    public class ProductStockEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// ProductId
        /// </summary>
        public Guid ProductId
        {
            get; set;
        }

        /// <summary>
        /// ProductId
        /// </summary>
        public string ProductName
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
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

    }
}



