// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   财务仓储
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
    /// 财务仓储
    /// </summary>
    public class OutlayRepository : TAFRepositoryBase<Outlay, Guid>, IOutlayRepository
    {
        public OutlayRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



