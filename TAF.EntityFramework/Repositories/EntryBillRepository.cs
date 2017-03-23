// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库单仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Storage;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 入库单仓储
    /// </summary>
    public class EntryBillRepository : TAFRepositoryBase<EntryBill, Guid>, IEntryBillRepository
    {
        public EntryBillRepository(IDbContextProvider<TAFDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
    }
}



