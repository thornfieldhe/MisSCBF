// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleIdAttachment.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   模块附件关联表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;

    /// <summary>
    /// 模块附件关联表
    /// </summary>
    public class ModuleIdAttachment : TAFEntity
    {
        public Guid ModuleId { get; set; }

        public Guid AttachmentId { get; set; }

    }
}