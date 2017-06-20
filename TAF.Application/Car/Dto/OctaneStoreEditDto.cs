// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Abp.AutoMapper;

    /// <summary>
    /// 实物油料库编辑对象
    /// </summary>
    [AutoMap(typeof(OctaneStore))]
    public class OctaneStoreEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }        
        
        /// <summary>
        /// StoreId
        /// </summary>
        public Guid StoreId
        {
            get; set;
        }        
        
        /// <summary>
        /// OctaneRatingId
        /// </summary>
        public Guid OctaneRatingId
        {
            get; set;
        }        
    } 
}



