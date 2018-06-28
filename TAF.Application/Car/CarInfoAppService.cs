﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarInfoAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆信息服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
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
    using SCBF.BaseInfo;
    using SCBF.Car.Dto;
    using TAF.Utility;

    /// <summary>
    /// 车辆信息服务
    /// </summary>
    [AbpAuthorize]
    public class CarInfoAppService : TAFAppServiceBase, ICarInfoAppService
    {
        private readonly ICarInfoRepository carInfoRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public CarInfoAppService(ICarInfoRepository carInfoRepository, ISysDictionaryRepository sysDictionaryRepository)
        {
            this.carInfoRepository = carInfoRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<CarInfoListDto> GetAll(CarInfoQueryDto request)
        {
            var query = this.carInfoRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Clxh), r => r.Clxh.Contains(request.Clxh))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Cjh), r => r.Cjh.Contains(request.Cjh))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Fdjh), r => r.Fdjh.Contains(request.Fdjh))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Cph), r => r.Cph.Contains(request.Cph))
                .WhereIf(request.Driver.HasValue, r => r.DriverId == request.Driver)
                .WhereIf(request.ZbsjFrom.HasValue, r => r.Zbsj >= request.ZbsjFrom.Value)
                .WhereIf(request.ZbsjTo.HasValue, r => r.Zbsj <= request.ZbsjTo.Value)
                .WhereIf(request.Clzk.HasValue, r => r.ClzkId == request.Clzk.Value)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Xszh), r => r.Xszh.Contains(request.Xszh));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Zbsj);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<CarInfoListDto>>();
            var octaneRatings = this.sysDictionaryRepository.GetAllList(r => r.Category == DictionaryCategory.Car_OctaneRating)
                .ToDictionary(r => r.Id, t => t.Value);
            foreach (var dto in dtos)
            {
                dto.Ylbh = octaneRatings[dto.OctaneRatingId.Value];
            }

            return new PagedResultDto<CarInfoListDto>(count, dtos);
        }


        public List<KeyValue<string, Guid>> GetSimple()
        {
            return this.carInfoRepository.GetAllList().Select(r => new KeyValue<string, Guid>() { Key = r.Cph, Value = r.Id }).ToList();
        }

        public CarInfoEditDto Get(Guid id)
        {
            var output = this.carInfoRepository.Get(id);
            return output.MapTo<CarInfoEditDto>();
        }

        public async Task SaveAsync(CarInfoEditDto input)
        {
            var item = input.MapTo<CarInfo>();
            if (!input.Id.HasValue)
            {
                await this.carInfoRepository.InsertAsync(item);
            }
            else
            {
                var old = this.carInfoRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.carInfoRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.carInfoRepository.Delete(id);
        }
    }
}



