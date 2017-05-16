// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   附件仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.BaseInfo;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 附件仓储
    /// </summary>
    public class AttachmentRepository : TAFRepositoryBase<Attachment, Guid>, IAttachmentRepository
    {
        public AttachmentRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



