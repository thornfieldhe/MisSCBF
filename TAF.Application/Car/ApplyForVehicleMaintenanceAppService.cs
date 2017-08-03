// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using Abp.UI;
    using AutoMapper;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using TAF.Utility;

    /// <summary>
    /// 车辆送修申请单服务
    /// </summary>
    [AbpAuthorize]
    public class ApplyForVehicleMaintenanceAppService : TAFAppServiceBase, IApplyForVehicleMaintenanceAppService
    {
        private readonly IApplyForVehicleMaintenanceRepository applyForVehicleMaintenanceRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IDriverRepository driverRepository;

        public ApplyForVehicleMaintenanceAppService(
            IApplyForVehicleMaintenanceRepository applyForVehicleMaintenanceRepository,
                                                    ISysDictionaryRepository sysDictionaryRepository,
                                                    IDriverRepository driverRepository)
        {
            this.applyForVehicleMaintenanceRepository = applyForVehicleMaintenanceRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.driverRepository = driverRepository;
        }

        public ListResultDto<ApplyForVehicleMaintenanceListDto> GetAll(ApplyForVehicleMaintenanceQueryDto request)
        {
            var query = this.applyForVehicleMaintenanceRepository.GetAll()

                .WhereIf(request.CarInfoId.HasValue, r => r.CarInfoId == request.CarInfoId.Value)
                .WhereIf(request.DriverId.HasValue, r => r.DriverId == request.DriverId.Value)
                .WhereIf(request.Status.HasValue, r => r.Status == request.Status.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ApplyForVehicleMaintenanceListDto>>();
            foreach (var dto in dtos)
            {
                var driver = this.driverRepository.Get(dto.DriverId);
                if (driver == null)
                {
                    throw new UserFriendlyException("驾驶员不能为空");
                }
                dto.DriverName = driver.Name;
                switch (dto.Status)
                {
                    case "0":
                        dto.Status = "等待审核";
                        break;
                    case "1":
                        dto.Status = "审核通过";
                        break;
                    case "2":
                        dto.Status = "审核拒绝";
                        break;
                }
            }

            return new PagedResultDto<ApplyForVehicleMaintenanceListDto>(count, dtos);
        }

        public ApplyForVehicleMaintenanceEditDto Get(Guid id)
        {
            var output = this.applyForVehicleMaintenanceRepository.Get(id);
            var result = output.MapTo<ApplyForVehicleMaintenanceEditDto>();
            var driver = this.driverRepository.Get(result.DriverId);
            if (driver == null)
            {
                throw new UserFriendlyException("驾驶员不能为空");
            }
            result.DriverName = driver.Name;
            return result;
        }

        public async Task SaveAsync(ApplyForVehicleMaintenanceEditDto input)
        {
            var item = input.MapTo<ApplyForVehicleMaintenance>();
            if (!input.Id.HasValue)
            {
                item.Code = GetMaxCode();
                await this.applyForVehicleMaintenanceRepository.InsertAsync(item);
            }
            else
            {
                var old = this.applyForVehicleMaintenanceRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.applyForVehicleMaintenanceRepository.UpdateAsync(old);
            }
        }

        public void Auding(KeyValue<Guid, int, string> input)
        {
            var item = this.applyForVehicleMaintenanceRepository.Get(input.Key);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不能为空");
            }
            item.Status = input.Value;
            item.Note2 = input.Item3;
            this.applyForVehicleMaintenanceRepository.Update(item);
        }

        public void Delete(Guid id)
        {
            this.applyForVehicleMaintenanceRepository.Delete(id);
        }


        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.applyForVehicleMaintenanceRepository.Get(r => r.Code.StartsWith("SXD" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"SXD{preCode}001";
            }
            else
            {
                return $"SXD{long.Parse(maxCode.Substring(3)) + 1}";
            }
        }
    }
}



