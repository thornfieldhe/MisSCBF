// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeliveryBillRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Storage;
    
    /// <summary>
    /// 出库单仓储接口
    /// </summary>
    public interface IDeliveryBillRepository : ITAFRepositoryBase<DeliveryBill>
    {

    }
}



