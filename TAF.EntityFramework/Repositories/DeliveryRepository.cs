// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryBillRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单仓储
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
    /// 出库单仓储
    /// </summary>
    public class DeliveryRepository : TAFRepositoryBase<Delivery, Guid>, IDeliveryRepository
    {
        public DeliveryRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



