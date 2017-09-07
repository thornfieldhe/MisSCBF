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

    using AutoMapper;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 采购计划预算关联表服务
    /// </summary>
    [AbpAuthorize]
    public class PlanWithBudgetOutlayAppService : TAFAppServiceBase, IPlanWithBudgetOutlayAppService
    {
        private readonly IPlanWithBudgetOutlayRepository _planWithBudgetOutlayRepository;

        public PlanWithBudgetOutlayAppService(IPlanWithBudgetOutlayRepository planWithBudgetOutlayRepository)
        {
            this._planWithBudgetOutlayRepository = planWithBudgetOutlayRepository;
        }

        public ListResultDto<PlanWithBudgetOutlayListDto> GetAll(PlanWithBudgetOutlayQueryDto request)
        {
            var query = this._planWithBudgetOutlayRepository.GetAll()

                .WhereIf(request.ProcurementPlanId.HasValue, r => r.ProcurementPlanId == request.ProcurementPlanId.Value)
                .WhereIf(request.BudgetOutlayId.HasValue, r => r.BudgetOutlayId == request.BudgetOutlayId.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<PlanWithBudgetOutlayListDto>>();

            return new PagedResultDto<PlanWithBudgetOutlayListDto>(count, dtos);
        }

        public PlanWithBudgetOutlayEditDto Get(Guid id)
        {
            var output = this._planWithBudgetOutlayRepository.Get(id);
            return output.MapTo<PlanWithBudgetOutlayEditDto>();
        }

        public async Task SaveAsync(PlanWithBudgetOutlayEditDto input)
        {
            var item = input.MapTo<PlanWithBudgetOutlay>();
            if (!input.Id.HasValue)
            {
                await this._planWithBudgetOutlayRepository.InsertAsync(item);
            }
            else
            {
                var old = this._planWithBudgetOutlayRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._planWithBudgetOutlayRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._planWithBudgetOutlayRepository.Delete(id);
        }
    }
}



