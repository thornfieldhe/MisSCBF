// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.Application.Services.Dto;

    /// <summary>
    /// 商品类别查询对象
    /// </summary>
    public class LayerQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// PId
        /// </summary>
        public Guid? PId
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

    }
}



