// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 入库单列表对象
    /// </summary>
    [AutoMap(typeof(EntryBill))]
    public class EntryBillListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
    } 
}



