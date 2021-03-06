﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 系统配置查询对象
    /// </summary>
    public class SysDictionaryQueryDto : PagedAndSortedResultRequestDto
    {

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
        /// Value2
        /// </summary>
        public string Value2
        {
            get; set;
        }

        /// <summary>
        /// Value3
        /// </summary>
        public string Value3
        {
            get; set;
        }

        /// <summary>
        /// Value4
        /// </summary>
        public string Value4
        {
            get; set;
        }

        /// <summary>
        /// Value5
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



