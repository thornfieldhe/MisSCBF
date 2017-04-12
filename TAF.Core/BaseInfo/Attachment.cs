// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Attachment.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Attachment
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 附件
    /// </summary>
    public class Attachment : TAFEntity
    {
        /// <summary>
        /// 附件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        public decimal Size { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 后缀
        /// </summary>
        public string Ext { get; set; }

        /// <summary>
        /// 附件类型
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public Guid ModuleId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        
    }
}