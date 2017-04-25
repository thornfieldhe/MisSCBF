// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReceiptRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   预算仓储
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
    /// 预算仓储
    /// </summary>
    public class ReceiptRepository : TAFRepositoryBase<Receipt, Guid>, IReceiptRepository
    {
        public ReceiptRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



