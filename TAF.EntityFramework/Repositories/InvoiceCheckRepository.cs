// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入仓储
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
    /// 发票录入仓储
    /// </summary>
    public class InvoiceCheckRepository : TAFRepositoryBase<InvoiceCheck, Guid>, IInvoiceCheckRepository
    {
        public InvoiceCheckRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



