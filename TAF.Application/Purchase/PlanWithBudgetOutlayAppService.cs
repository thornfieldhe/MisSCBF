// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlanWithBudgetOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购计划预算关联表服务
    /// </summary>
    [AbpAuthorize]
    public class PlanWithBudgetOutlayAppService : TAFAppServiceBase, IPlanWithBudgetOutlayAppService
    {
        private readonly IPlanWithBudgetOutlayRepository planWithBudgetOutlayRepository;
        private readonly IBudgetOutlayRepository budgetOutlayRepository;

        public PlanWithBudgetOutlayAppService(IPlanWithBudgetOutlayRepository planWithBudgetOutlayRepository, IBudgetOutlayRepository budgetOutlayRepository)
        {
            this.planWithBudgetOutlayRepository = planWithBudgetOutlayRepository;
            this.budgetOutlayRepository = budgetOutlayRepository;
        }

        public ListResultDto<PlanWithBudgetOutlayListDto> GetCorrelatedOutlays(PlanWithBudgetOutlayQueryDto request)
        {
            if (!request.Pid.HasValue)
            {
                throw new UserFriendlyException("采购计划不能为空");
            }

            var query = this.planWithBudgetOutlayRepository.GetAll()
                .Where(r => r.ProcurementPlanId == request.Pid).OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<PlanWithBudgetOutlayListDto>>();

            return new PagedResultDto<PlanWithBudgetOutlayListDto>(count, dtos);
        }

        public ListResultDto<PlanWithBudgetOutlayListDto> GetUnCorrelatedOutlays(PlanWithBudgetOutlayQueryDto request)
        {
            if (!request.Year.HasValue)
            {
                request.Year = DateTime.Now.Year;
            }

            var correlatedIds = this.planWithBudgetOutlayRepository.GetAll()
                .Where(r => r.ProcurementPlan.Date.Year == request.Year.Value).Select(r => r.BudgetOutlayId);
            var query = this.budgetOutlayRepository.GetAll()
                .Where(r => correlatedIds.All(m => m != r.Id) && r.BudgetReceiptId.HasValue && r.Type==request.Type)
                .WhereIf(!string.IsNullOrEmpty(request.Name), r => r.Name.Contains(request.Name))
                .OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<PlanWithBudgetOutlayListDto>>();

            return new PagedResultDto<PlanWithBudgetOutlayListDto>(count, dtos);
        }

        public async Task SaveAsync(PlanWithBudgetOutlayEditDto input)
        {
            var item = input.MapTo<PlanWithBudgetOutlay>();
            await this.planWithBudgetOutlayRepository.InsertAsync(item);
        }

        public void Delete(Guid id)
        {
            this.planWithBudgetOutlayRepository.Delete(id);
        }
    }
}



