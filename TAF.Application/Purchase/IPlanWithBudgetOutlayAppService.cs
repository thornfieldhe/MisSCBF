// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlanWithBudgetOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.Purchase.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 采购计划预算关联表应用接口
    /// </summary>
    public interface IPlanWithBudgetOutlayAppService : IBaseEntityApplicationService
    {
        ListResultDto<PlanWithBudgetOutlayListDto> GetAll(PlanWithBudgetOutlayQueryDto request);

        PlanWithBudgetOutlayEditDto Get(Guid id);

        Task SaveAsync(PlanWithBudgetOutlayEditDto input);

        void Delete(Guid id);
    }
}



