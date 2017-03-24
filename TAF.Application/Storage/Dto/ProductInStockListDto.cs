// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 库存列表对象
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductInStockListDto
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
        /// Unit
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// StorageName
        /// </summary>
        public string StorageName
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
        /// 库存量
        /// </summary>
        public decimal StockBalance
        {
            get; set;
        }
    }
}



