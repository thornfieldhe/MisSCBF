// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using Abp.Application.Services.Dto;
    using System;

    /// <summary>
    /// 实物油料库查询对象
    /// </summary>
    public class OctaneStoreQueryDto : PagedAndSortedResultRequestDto
    {

        /// <summary>
        /// StoreId
        /// </summary>
        public Guid? StoreId
        {
            get; set;
        }
    }
}



