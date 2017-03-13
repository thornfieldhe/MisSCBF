// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 系统配置列表对象
    /// </summary>
    [AutoMap(typeof(SysDictionary))]
    public class SysDictionaryListDto
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
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }
    }
}



