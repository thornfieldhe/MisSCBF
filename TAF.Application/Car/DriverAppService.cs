// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriverAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   驾驶员服务
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
    /// 驾驶员服务
    /// </summary>
    [AbpAuthorize]
    public class DriverAppService : TAFAppServiceBase, IDriverAppService
    {
        private readonly IDriverRepository driverRepository;

        public DriverAppService(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public ListResultDto<DriverListDto> GetAll(PagedAndSortedResultRequestDto request)
        {
            var query = this.driverRepository.GetAll();
            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<DriverListDto>>();

            return new PagedResultDto<DriverListDto>(count, dtos);
        }

        public DriverEditDto Get(Guid id)
        {
            var output = this.driverRepository.Get(id);
            return output.MapTo<DriverEditDto>();
        }

        public async Task SaveAsync(DriverEditDto input)
        {
            var item = input.MapTo<Driver>();
            if (input.Id == Guid.Empty)
            {
                await this.driverRepository.InsertAsync(item);
            }
            else
            {
                var old = this.driverRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.driverRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.driverRepository.Delete(id);
        }
    }
}



