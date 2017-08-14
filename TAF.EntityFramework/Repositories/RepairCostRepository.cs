// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepairCostRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单仓储
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
    /// 车辆维修审批单仓储
    /// </summary>
    public class RepairCostRepository : TAFRepositoryBase<RepairCost, Guid>, IRepairCostRepository
    {
        public RepairCostRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



