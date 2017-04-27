// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   商品列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 商品列表对象
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductListDto
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
        /// Name
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// Specifications
        /// </summary>
        public string Specifications
        {
            get; set;
        }

        /// <summary>
        /// Color
        /// </summary>
        public string Unit
        {
            get; set;
        }
    }
}



