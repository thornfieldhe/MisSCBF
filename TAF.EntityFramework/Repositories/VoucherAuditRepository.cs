// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Finance;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 凭证审核归纳表仓储
    /// </summary>
    public class VoucherAuditRepository : TAFRepositoryBase<VoucherAudit, Guid>, IVoucherAuditRepository
    {
        public VoucherAuditRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



