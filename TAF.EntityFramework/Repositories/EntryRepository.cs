// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库仓储
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
    /// 入库仓储
    /// </summary>
    public class EntryRepository : TAFRepositoryBase<Entry, Guid>, IEntryRepository
    {
        public EntryRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



