// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using AutoMapper;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    /// <summary>
    /// 实物油料库服务
    /// </summary>
    [AbpAuthorize]
    public class OctaneStoreAppService : TAFAppServiceBase, IOctaneStoreAppService
    {
        private readonly IOctaneStoreRepository octaneStoreRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public OctaneStoreAppService(IOctaneStoreRepository octaneStoreRepository, ISysDictionaryRepository sysDictionaryRepository)
        {
            this.octaneStoreRepository = octaneStoreRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<OctaneStoreListDto> GetAll(OctaneStoreQueryDto request)
        {
            var query = this.octaneStoreRepository.GetAll()

                .WhereIf(request.StoreId.HasValue, r => r.StoreId == request.StoreId.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();

            var dtos = new List<OctaneStoreListDto>();
            foreach (var store in list)
            {
                var dto = new OctaneStoreListDto
                {
                    Id = store.Id,
                    OctaneRatingName =
                                      this.sysDictionaryRepository
                                          .FirstOrDefault(store.OctaneRatingId).Value,
                    StoreName = this.sysDictionaryRepository
                                      .FirstOrDefault(store.StoreId).Value,
                    Amount = store.Amount
                };
                dtos.Add(dto);
            }

            return new PagedResultDto<OctaneStoreListDto>(count, dtos);
        }

        public OctaneStoreEditDto Get(Guid id)
        {
            var output = this.octaneStoreRepository.Get(id);
            return output.MapTo<OctaneStoreEditDto>();
        }

        public async Task SaveAsync(OctaneStoreEditDto input)
        {
            var item = input.MapTo<OctaneStore>();
            if (!input.Id.HasValue)
            {
                await this.octaneStoreRepository.InsertAsync(item);
            }
            else
            {
                var old = this.octaneStoreRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.octaneStoreRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.octaneStoreRepository.Delete(id);
        }
    }
}



