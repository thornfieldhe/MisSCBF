// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理仓储
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
    /// 招标文件管理仓储
    /// </summary>
    public class BiddingManagementRepository : TAFRepositoryBase<BiddingManagement, Guid>, IBiddingManagementRepository
    {
        public BiddingManagementRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



