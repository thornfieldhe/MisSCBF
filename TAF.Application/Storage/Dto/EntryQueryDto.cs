// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   入库查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 入库查询对象
    /// </summary>
    public class EntryQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// 商品
        /// </summary>
        public string Product
        {
            get; set;
        }

        /// <summary>
        /// StorageId
        /// </summary>
        public Guid? StorageId
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
        /// IsSpecial
        /// </summary>
        public bool IsSpecial
        {
            get; set;
        }

        /// <summary>
        /// 入库时间起
        /// </summary>
        public DateTime? DateFrom
        {
            get; set;
        }

        /// <summary>
        /// 入库时间止
        /// </summary>
        public DateTime? DateTo
        {
            get; set;
        }

    }
}



