// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlanWithBudgetOutlayRepository.cs" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 采购计划预算关联表仓储接口
    /// </summary>
    public interface IPlanWithBudgetOutlayRepository : ITAFRepositoryBase<PlanWithBudgetOutlay>
    {

    }
}



