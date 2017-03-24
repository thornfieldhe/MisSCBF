// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库单编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 出入库单编辑对象
    /// </summary>
    public class StockBillEditDto
    {
        public StockBillEditDto()
        {
            this.Items = new List<ProductStockListDto>();
        }

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
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// IsSpecial
        /// </summary>
        public bool IsSpecial
        {
            get; set;
        }


        public virtual List<ProductStockListDto> Items
        {
            get; set;
        }
    }
}



