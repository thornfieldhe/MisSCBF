// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceRepository.cs" company="" author="何翔华">
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
    public class InvoiceRepository : TAFRepositoryBase<Invoice, Guid>, IInvoiceRepository
    {
        public InvoiceRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



