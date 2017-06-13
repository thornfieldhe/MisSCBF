// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBillRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点仓储
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
    /// 盘点仓储
    /// </summary>
    public class CheckBillRepository : TAFRepositoryBase<CheckBill, Guid>, ICheckBillRepository
    {
        public CheckBillRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



