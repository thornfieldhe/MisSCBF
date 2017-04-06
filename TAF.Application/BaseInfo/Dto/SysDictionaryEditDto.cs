// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 系统配置编辑对象
    /// </summary>
    [AutoMap(typeof(SysDictionary))]
    public class SysDictionaryEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Key
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value2
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value3
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value4
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value5
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



