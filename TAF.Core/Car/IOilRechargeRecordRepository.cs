// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOilRechargeRecordRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Car;
    
    /// <summary>
    /// 实物油料入库单仓储接口
    /// </summary>
    public interface IOilRechargeRecordRepository : ITAFRepositoryBase<OilRechargeRecord>
    {

    }
}



