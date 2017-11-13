// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段服务
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
    /// 采购阶段服务
    /// </summary>
    [AbpAuthorize]
    public class StageInfoeAppService : TAFAppServiceBase, IStageInfoeAppService
    {
        private readonly IStageInfoRepository stageInfoRepository;

        public StageInfoeAppService(IStageInfoRepository stageInfoRepository)
        {
            this.stageInfoRepository = stageInfoRepository;
        }

        public ListResultDto<StageInfoListDto> GetAll(StageInfoeQueryDto request)
        {
            var query = this.stageInfoRepository.GetAll()

                .WhereIf(request.Category.HasValue, r => (int)r.Category == request.Category.Value)
                .WhereIf(request.Company.HasValue, r => r.Company == request.Company.Value)
                .WhereIf(request.Cost.HasValue, r => r.Cost == request.Cost.Value)
                .WhereIf(request.Status.HasValue, r => r.Status == request.Status.Value)
                .WhereIf(request.ProcurementPlanId.HasValue, r => r.ProcurementPlanId == request.ProcurementPlanId.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<StageInfoListDto>>();

            return new PagedResultDto<StageInfoListDto>(count, dtos);
        }

        public StageInfoEditDto Get(Guid id)
        {
            var output = this.stageInfoRepository.Get(id);
            return output.MapTo<StageInfoEditDto>();
        }

        public async Task SaveAsync(StageInfoEditDto input)
        {
            var item = input.MapTo<StageInfo>();
            if (!input.Id.HasValue)
            {
                await this.stageInfoRepository.InsertAsync(item);
            }
            else
            {
                var old = this.stageInfoRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.stageInfoRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.stageInfoRepository.Delete(id);
        }
    }
}



