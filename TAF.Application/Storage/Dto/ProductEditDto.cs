// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   商品编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 商品编辑对象
    /// </summary>
    [AutoMap(typeof(Product))]
    public class ProductEditDto
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
        /// 商品分类
        /// </summary>
        public Guid CategoryId
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
        /// PYCode
        /// </summary>
        public string PYCode
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
        /// Unit2
        /// </summary>
        public string Unit2
        {
            get; set;
        }

        /// <summary>
        /// UnitConversion
        /// </summary>
        public double UnitConversion
        {
            get; set;
        }

        /// <summary>
        /// Color
        /// </summary>
        public string Color
        {
            get; set;
        }

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand
        {
            get; set;
        }

        /// <summary>
        /// Note1
        /// </summary>
        public string Note1
        {
            get; set;
        }

        /// <summary>
        /// Note2
        /// </summary>
        public string Note2
        {
            get; set;
        }

        /// <summary>
        /// Order
        /// </summary>
        public string Order
        {
            get; set;
        }
    }
}



