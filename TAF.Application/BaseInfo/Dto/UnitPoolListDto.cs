// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPoolListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   模块附件关联列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.AutoMapper;

namespace SCBF.BaseInfo.Dto
{
    using System;

    /// <summary>
    /// 模块附件关联列表对象
    /// </summary>
    [AutoMap(typeof(UnitPool))]
    public class UnitPoolListDto
    {
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// ItemId
        /// </summary>
        public Guid ItemId
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
        /// 选中状态
        /// </summary>
        public bool IsSelected
        {
            get; set;
        }
    } 
}



