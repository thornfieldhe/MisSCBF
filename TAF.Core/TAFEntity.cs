// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TAFEntity.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   TAFEntity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Entities;
    using Abp.Domain.Entities.Auditing;

    /// <summary>
    /// TAF实体基类，包含软删除和审计接口
    /// </summary>
    public class TAFEntity : Entity<Guid>, IAudited
    {
        public DateTime CreationTime
        {
            get; set;
        }

        public long? CreatorUserId
        {
            get; set;
        }

        public DateTime? LastModificationTime
        {
            get; set;
        }

        public long? LastModifierUserId
        {
            get; set;
        }
    }
}