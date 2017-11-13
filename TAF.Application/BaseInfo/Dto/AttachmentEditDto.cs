// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   附件编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 附件编辑对象
    /// </summary>
    [AutoMap(typeof(Attachment))]
    public class AttachmentEditDto
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
    }
}



