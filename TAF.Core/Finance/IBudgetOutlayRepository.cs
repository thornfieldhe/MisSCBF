// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBudgetOutlayRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 支出预算仓储接口
    /// </summary>
    public interface IBudgetOutlayRepository : ITAFRepositoryBase<BudgetOutlay>
    {

    }
}



