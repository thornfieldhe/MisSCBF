// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理仓储
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
    /// 开标管理仓储
    /// </summary>
    public class BidOpeningManagementRepository : TAFRepositoryBase<BidOpeningManagement, Guid>, IBidOpeningManagementRepository
    {
        public BidOpeningManagementRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



