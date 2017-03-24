// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   库存编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 库存编辑对象
    /// </summary>
    [AutoMap(typeof(Stock))]
    public class StockEditDto
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
        /// Amount
        /// </summary>
        public decimal Amount
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
    } 
}



