// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRechargeRecordRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Car;
    
    /// <summary>
    /// 油料分配记录仓储接口
    /// </summary>
    public interface IRechargeRecordRepository : ITAFRepositoryBase<RechargeRecord>
    {

    }
}



