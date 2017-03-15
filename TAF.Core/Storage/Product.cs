// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Product
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Product : TAFEntity
    {
        /// <summary>
        /// 商品名称
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
        /// 规格
        /// </summary>
        public string Specifications
        {
            get; set;
        }

        /// <summary>
        /// 条形码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string PYCode
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
        /// 辅助单位
        /// </summary>
        public string Unit2
        {
            get; set;
        }

        /// <summary>
        /// 单位换算
        /// </summary>
        public double UnitConversion
        {
            get; set;
        }

        /// <summary>
        /// 颜色
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
        /// 备注1
        /// </summary>
        public string Note1
        {
            get; set;
        }

        /// <summary>
        /// 备注2
        /// </summary>
        public string Note2
        {
            get; set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order
        {
            get; set;
        }
    }
}