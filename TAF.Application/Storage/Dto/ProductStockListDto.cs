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
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 库存列表对象
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductStockListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid ProductId
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
        /// 规格
        /// </summary>
        public string Specifications
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
        /// 金额
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
        /// StorageId
        /// </summary>
        public Guid StorageId
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

        public bool Status
        {
            get; set;
        }
    }
}



