// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
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

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 系统配置服务
    /// </summary>
    [AbpAuthorize]
    public class SysDictionaryAppService : TAFAppServiceBase, ISysDictionaryAppService
    {
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public SysDictionaryAppService(ISysDictionaryRepository sysDictionaryRepository)
        {
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<SysDictionaryListDto> GetAll(SysDictionaryQueryDto request)
        {
            var query =
                this.sysDictionaryRepository.GetAll()
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Category), r => r.Category.Contains(request.Category))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Value), r => r.Value.Contains(request.Value));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Category);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<SysDictionaryListDto>>();

            return new PagedResultDto<SysDictionaryListDto>(count, dtos);
        }

        public SysDictionaryEditDto Get(Guid id)
        {
            var output = this.sysDictionaryRepository.Get(id);
            return output.MapTo<SysDictionaryEditDto>();
        }

        public async Task SaveAsync(SysDictionaryEditDto input)
        {
            var item = input.MapTo<SysDictionary>();
            if (input.Id == Guid.Empty)
            {
                await this.sysDictionaryRepository.InsertAsync(item);
            }
            else
            {
                var old = this.sysDictionaryRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.sysDictionaryRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.sysDictionaryRepository.Delete(id);
        }

        public List<SysDictionaryListDto> GetSimpleList()
        {
            return this.sysDictionaryRepository.GetAll().MapTo<List<SysDictionaryListDto>>();
        }
    }
}



