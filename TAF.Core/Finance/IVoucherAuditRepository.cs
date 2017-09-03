// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVoucherAuditRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 凭证审核归纳表仓储接口
    /// </summary>
    public interface IVoucherAuditRepository : ITAFRepositoryBase<VoucherAudit>
    {

    }
}



