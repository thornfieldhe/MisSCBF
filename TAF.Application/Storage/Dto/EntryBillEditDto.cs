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
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 入库单编辑对象
    /// </summary>
    [AutoMap(typeof(EntryBill))]
    public class EntryBillEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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


        public virtual List<EntryEditDto> Entries
        {
            get; set;
        }
    } 
}



