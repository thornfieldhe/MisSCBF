// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   关系管理编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 关系管理编辑对象
    /// </summary>
    [AutoMap(typeof(Relationship))]
    public class RelationshipEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }        
        
        /// <summary>
        /// PrincipalKey
        /// </summary>
        public Guid PrincipalKey
        {
            get; set;
        }        
        
        /// <summary>
        /// ForeignKey
        /// </summary>
        public Guid ForeignKey
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



