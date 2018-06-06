// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipQueryDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   关系管理查询对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;
    
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 关系管理查询对象
    /// </summary>
    public class RelationshipQueryDto : PagedAndSortedResultRequestDto
    {  
        
        /// <summary>
        /// PrincipalKey
        /// </summary>
        public Guid? PrincipalKey
        {
            get; set;
        }        
        
        /// <summary>
        /// ForeignKey
        /// </summary>
        public Guid? ForeignKey
        {
            get; set;
        }        
        
        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get; set;
        }        
    } 
}



