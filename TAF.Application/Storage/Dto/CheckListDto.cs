// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   盘点列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 盘点列表对象
    /// </summary>
    [AutoMap(typeof(Check))]
    public class CheckListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
        /// <summary>
        /// ProductName
        /// </summary>
        public string ProductName
        {
            get; set;
        }    
        
        /// <summary>
        /// StockAmount
        /// </summary>
        public decimal StockAmount
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
        /// ChangedAmount
        /// </summary>
        public decimal ChangedAmount
        {
            get; set;
        }        
        
        /// <summary>
        /// Reason
        /// </summary>
        public string Reason
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
        /// StorageName
        /// </summary>
        public string StorageName
        {
            get; set;
        }    
    } 
}



