// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡服务
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
    using TAF.Utility;

    /// <summary>
    /// 油料卡服务
    /// </summary>
    [AbpAuthorize]
    public class OilCardAppService : TAFAppServiceBase, IOilCardAppService
    {
        private readonly IOilCardRepository oilCardRepository;

        public OilCardAppService(IOilCardRepository oilCardRepository)
        {
            this.oilCardRepository = oilCardRepository;
        }

        public ListResultDto<OilCardListDto> GetAll(OilCardQueryDto request)
        {
            var query = this.oilCardRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code))
                .WhereIf(!string.IsNullOrWhiteSpace(request.CarInfoName), r => r.CarInfo.Cph.Contains(request.CarInfoName));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.CarInfo.Cph);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<OilCardListDto>>();

            return new PagedResultDto<OilCardListDto>(count, dtos);
        }

        public OilCardEditDto Get(Guid id)
        {
            var output = this.oilCardRepository.Get(id);
            return output.MapTo<OilCardEditDto>();
        }

        public decimal GetAmount(Guid id)
        {
            var output = this.oilCardRepository.Get(id);
            return output.Amount;
        }

        public List<KeyValue<string, Guid>> GetSimple()
        {
            return this.oilCardRepository.GetAllList()
            .Select(r => new KeyValue<string, Guid>() { Value = r.Id, Key = r.Code }).ToList();
        }

        public async Task SaveAsync(OilCardEditDto input)
        {
            var item = input.MapTo<OilCard>();
            if (!input.Id.HasValue)
            {
                await this.oilCardRepository.InsertAsync(item);
            }
            else
            {
                var old = this.oilCardRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.oilCardRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.oilCardRepository.Delete(id);
        }
    }
}



