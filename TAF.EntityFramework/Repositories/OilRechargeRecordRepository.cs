// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilRechargeRecordRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Car;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 实物油料入库单仓储
    /// </summary>
    public class OilRechargeRecordRepository : TAFRepositoryBase<OilRechargeRecord, Guid>, IOilRechargeRecordRepository
    {
        public OilRechargeRecordRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



