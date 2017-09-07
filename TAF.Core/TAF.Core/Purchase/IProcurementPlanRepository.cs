// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProcurementPlanRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度采购计划仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Purchase;
    
    /// <summary>
    /// 年度采购计划仓储接口
    /// </summary>
    public interface IProcurementPlanRepository : ITAFRepositoryBase<ProcurementPlan>
    {

    }
}



