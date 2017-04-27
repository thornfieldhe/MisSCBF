// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   商品查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 商品查询对象
    /// </summary>
    public class ProductQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specifications
        {
            get; set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// 商品分类
        /// </summary>
        public Guid CategoryId
        {
            get; set;
        }
    }
}



