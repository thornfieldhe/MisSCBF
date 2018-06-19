// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Purchase;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 采购过程管理仓储
    /// </summary>
    public class AuditManagementRepository : TAFRepositoryBase<AuditManagement, Guid>, IAuditManagementRepository
    {
        public AuditManagementRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



