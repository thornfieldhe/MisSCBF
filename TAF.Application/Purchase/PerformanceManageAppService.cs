// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceManageAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;

    using AutoMapper;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 履约保证金管理服务
    /// </summary>
    [AbpAuthorize]
    public class PerformanceManageAppService : TAFAppServiceBase, IPerformanceManageAppService
    {
        private readonly IPerformanceManageRepository _performanceManageRepository;

        public PerformanceManageAppService(IPerformanceManageRepository performanceManageRepository)
        {
            this._performanceManageRepository = performanceManageRepository;
        }
        public PerformanceManageEditDto Get(Guid planId)
        {
            var output = this._performanceManageRepository.FirstOrDefault(r=>r.PlanId==planId);
            return output ==null ? new PerformanceManageEditDto(){PlanId = planId} : output.MapTo<PerformanceManageEditDto>();
        }

        public async Task SaveAsync(PerformanceManageEditDto input)
        {
            var item = input.MapTo<PerformanceManage>();
            if (!input.Id.HasValue)
            {
                await this._performanceManageRepository.InsertAsync(item);
            }
            else
            {
                var old = this._performanceManageRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._performanceManageRepository.UpdateAsync(old);
            }
        }
    }
}



