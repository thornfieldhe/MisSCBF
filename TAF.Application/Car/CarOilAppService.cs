// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表服务
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
    /// 车辆油料核算表服务
    /// </summary>
    [AbpAuthorize]
    public class CarOilAppService : TAFAppServiceBase, ICarOilAppService
    {
        private readonly ICarOilRepository _carOilRepository;

        public CarOilAppService(ICarOilRepository _carOilRepository)
        {
            this._carOilRepository = _carOilRepository;
        }

        public ListResultDto<CarOilListDto> GetAll(CarOilQueryDto request)
        {
            var query = this._carOilRepository.GetAll()

                .WhereIf(request.CarInfoId.HasValue, r => r.CarInfoId == request.CarInfoId.Value)
                .WhereIf(request.Kilometres.HasValue, r => r.Kilometres == request.Kilometres.Value)
                .WhereIf(request.Year.HasValue, r => r.Year == request.Year.Value)
                .WhereIf(request.Month.HasValue, r => r.Month == request.Month.Value)
                .WhereIf(request.Amount.HasValue, r => r.Amount == request.Amount.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<CarOilListDto>>();

            return new PagedResultDto<CarOilListDto>(count, dtos);
        }

        public CarOilEditDto Get(Guid id)
        {
            var output = this._carOilRepository.Get(id);
            return output.MapTo<CarOilEditDto>();
        }

        public async Task SaveAsync(CarOilEditDto input)
        {
            var item = input.MapTo<CarOil>();
            if (!input.Id.HasValue)
            {
                await this._carOilRepository.InsertAsync(item);
            }
            else
            {
                var old = this._carOilRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._carOilRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._carOilRepository.Delete(id);
        }
    }
}



