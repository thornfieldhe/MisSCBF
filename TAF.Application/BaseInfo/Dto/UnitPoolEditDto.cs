// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPoolEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   模块附件关联编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SCBF.BaseInfo.Dto
{

    using Abp.AutoMapper;

    /// <summary>
    /// 模块附件关联编辑对象
    /// </summary>
    [AutoMap(typeof(UnitPool))]
    public class UnitPoolEditDto
    {
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        public List<Guid> Ids { get; set; }
    }
}



