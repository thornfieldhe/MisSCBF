// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EquipObject.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 车辆维修耗时管理查询对象
    /// </summary>
    public class EquipQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// LayerId
        /// </summary>
        public Guid? LayerId
        {
            get; set;
        }        
        
        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get; set;
        }        
        
        /// <summary>
        /// Content
        /// </summary>
        public string Content
        {
            get; set;
        }        
    } 
}



