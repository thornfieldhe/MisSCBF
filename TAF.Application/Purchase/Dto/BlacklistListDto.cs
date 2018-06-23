// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 会质量评价体系列表对象
    /// </summary>
    [AutoMap(typeof(Blacklist))]
    public class BlacklistListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
        /// Type
        /// </summary>
        public string Type
        {
            get; set;
        }        
    } 
}



