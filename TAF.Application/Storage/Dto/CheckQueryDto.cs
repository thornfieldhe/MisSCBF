// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   盘点查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 盘点查询对象
    /// </summary>
    public class CheckQueryDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// ProductCode
        /// </summary>
        public string ProductCode
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
        /// BillId
        /// </summary>
        public Guid? BillId
        {
            get; set;
        }

    }
}



