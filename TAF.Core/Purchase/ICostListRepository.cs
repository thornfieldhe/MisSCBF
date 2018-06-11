// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICostListRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   造价清单管理仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 造价清单管理仓储接口
    /// </summary>
    public interface ICostListRepository : ITAFRepositoryBase<CostList>
    {

    }
}



