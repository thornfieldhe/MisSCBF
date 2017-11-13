// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStageInfoUserRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段用户仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 采购阶段用户仓储接口
    /// </summary>
    public interface IStageInfoUserRepository : ITAFRepositoryBase<StageInfoUser>
    {

    }
}



