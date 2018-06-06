// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   关系管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 关系管理列表对象
    /// </summary>
    [AutoMap(typeof(Relationship))]
    public class RelationshipListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
        /// <summary>
        /// PrincipalKey
        /// </summary>
        public string PrincipalKey
        {
            get; set;
        }    
        
        /// <summary>
        /// ForeignKey
        /// </summary>
        public string ForeignKey
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



