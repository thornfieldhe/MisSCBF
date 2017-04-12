// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   附件列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 附件列表对象
    /// </summary>
    [AutoMap(typeof(Attachment))]
    public class AttachmentListDto
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
        /// Size
        /// </summary>
        public decimal Size
        {
            get; set;
        }        
        
        /// <summary>
        /// Path
        /// </summary>
        public string Path
        {
            get; set;
        }        
        
        /// <summary>
        /// Ext
        /// </summary>
        public string Ext
        {
            get; set;
        }        
        
        /// <summary>
        /// Category
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// ModuleId
        /// </summary>
        public Guid ModuleId
        {
            get; set;
        }    
        
        /// <summary>
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }        
    } 
}



