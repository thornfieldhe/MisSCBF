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
    using Abp.Application.Services.Dto;
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购计划预算关联表应用接口
    /// </summary>
    public interface IPlanWithBudgetOutlayAppService : IBaseEntityApplicationService
    {
        ListResultDto<PlanWithBudgetOutlayListDto> GetCorrelatedOutlays(PlanWithBudgetOutlayQueryDto request);

        ListResultDto<PlanWithBudgetOutlayListDto> GetUnCorrelatedOutlays(PlanWithBudgetOutlayQueryDto request);

        Task SaveAsync(PlanWithBudgetOutlayEditDto input);

        void Delete(Guid id);
    }
}



