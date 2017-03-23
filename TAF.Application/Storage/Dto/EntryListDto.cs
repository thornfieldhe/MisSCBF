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
    /// 入库列表对象
    /// </summary>
    [AutoMap(typeof(Entry))]
    public class EntryListDto
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
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }
    }
}



