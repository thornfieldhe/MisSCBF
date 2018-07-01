// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using SCBF.BaseInfo;

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
    using Abp.UI;
    using AutoMapper;
    using SCBF.Car.Dto;
    using TAF.Utility;

    /// <summary>
    /// 车辆送修申请单服务
    /// </summary>
    [AbpAuthorize]
    public class ApplyForVehicleMaintenanceAppService : TAFAppServiceBase, IApplyForVehicleMaintenanceAppService
    {
        private readonly IApplyForVehicleMaintenanceRepository _applyForVehicleMaintenanceRepository;
        private readonly IDriverRepository                     _driverRepository;
        private readonly IMaintenanceDeliveryRepository        _maintenanceDeliveryRepository;
        private readonly ICarInfoRepository                    _carInfoRepository;
        private readonly IServicingMaterialRepository          _servicingMaterialRepository;
        private readonly IManHourRepository                    _manHourRepository;
        private readonly ILayerRepository                      _layerRepository;
        private readonly ISysDictionaryRepository              _sysDictionaryRepository;
        private readonly IDeliveryRepository                   _deliveryRepository;
        private readonly IRepairCostRepository                 _repairCostRepository;
        private readonly ICarRepairTimeRepository              _carRepairTimeRepository;

        public ApplyForVehicleMaintenanceAppService(
            IApplyForVehicleMaintenanceRepository applyForVehicleMaintenanceRepository,
            IDriverRepository                     driverRepository,
            IMaintenanceDeliveryRepository        maintenanceDeliveryRepository,
            ICarInfoRepository                    carInfoRepository,
            ISysDictionaryRepository              sysDictionaryRepository,
            IRepairCostRepository                 repairCostRepository,
            ICarRepairTimeRepository              carRepairTimeRepository,
            ILayerRepository                      layerRepository,
            IDeliveryRepository                   deliveryRepository,
            IServicingMaterialRepository          servicingMaterialRepository,
            IManHourRepository                    manHourRepository
        )
        {
            this._applyForVehicleMaintenanceRepository = applyForVehicleMaintenanceRepository;
            this._deliveryRepository                   = deliveryRepository;
            this._driverRepository                     = driverRepository;
            this._layerRepository                      = layerRepository;
            this._repairCostRepository                 = repairCostRepository;
            this._carRepairTimeRepository              = carRepairTimeRepository;
            this._sysDictionaryRepository              = sysDictionaryRepository;
            this._maintenanceDeliveryRepository        = maintenanceDeliveryRepository;
            this._carInfoRepository                    = carInfoRepository;
            this._servicingMaterialRepository          = servicingMaterialRepository;
            this._manHourRepository                    = manHourRepository;
        }

        public ListResultDto<ApplyForVehicleMaintenanceListDto> GetAll(ApplyForVehicleMaintenanceQueryDto request)
        {
            var query = this._applyForVehicleMaintenanceRepository.GetAll()
                .WhereIf(request.CarInfoId.HasValue, r => r.CarInfoId           == request.CarInfoId.Value)
                .WhereIf(request.DriverId.HasValue, r => r.DriverId             == request.DriverId.Value)
                .WhereIf(request.ServiceDepotId.HasValue, r => r.ServiceDepotId == request.ServiceDepotId.Value)
                .WhereIf(request.Status.HasValue, r => r.Status                 == request.Status.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                ? query.OrderBy(request.Sorting)
                : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = list.MapTo<List<ApplyForVehicleMaintenanceListDto>>();
            foreach (var dto in dtos)
            {
                var driver = this._driverRepository.Get(dto.DriverId);
                dto.ServiceDepot = this._sysDictionaryRepository.Get(r => r.Id == dto.ServiceDepotId).FirstOrDefault()
                    ?.Value;
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
                    case "3":
                        dto.Status = "维修中";
                        break;
                    case "4":
                        dto.Status = "修理完成";
                        break;
                }
            }

            return new PagedResultDto<ApplyForVehicleMaintenanceListDto>(count, dtos);
        }

        public PagedResultDto<ApplyForVehicleMaintenanceListDto> GetAuditedItems(
            ApplyForVehicleMaintenanceQueryDto request)
        {
            var query = this._applyForVehicleMaintenanceRepository.GetAll()
                .Where(r => r.Status == request.Status.Value).OrderByDescending(r => r.CreationTime);

            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = list.MapTo<List<ApplyForVehicleMaintenanceListDto>>();
            foreach (var dto in dtos)
            {
                var driver = this._driverRepository.Get(dto.DriverId);
                if (driver == null)
                {
                    throw new UserFriendlyException("驾驶员不能为空");
                }

                dto.DriverName = driver.Name;
                dto.ServiceDepot = this._sysDictionaryRepository.Get(r => r.Id == dto.ServiceDepotId).FirstOrDefault()
                    ?.Value;
            }

            return new PagedResultDto<ApplyForVehicleMaintenanceListDto>(count, dtos);
        }

        public ApplyForVehicleMaintenanceEditDto Get(Guid id)
        {
            var output = this._applyForVehicleMaintenanceRepository.Get(id);
            var result = output.MapTo<ApplyForVehicleMaintenanceEditDto>();
            var driver = this._driverRepository.Get(result.DriverId);
            if (driver == null)
            {
                throw new UserFriendlyException("驾驶员不能为空");
            }

            if (!string.IsNullOrWhiteSpace(result.RepairType))
            {
                switch (result.RepairType)
                {
                    case "Car_Overhaul":
                        result.RepairTypeName = "大修";
                        break;
                    case "Car_Repair":
                        result.RepairTypeName = "中修";
                        break;
                    case "Car_MinorRepair":
                        result.RepairTypeName = "小修";
                        break;
                }
            }

            result.DriverName = driver.Name;
            result.ServiceDepot = this._sysDictionaryRepository.Get(r => r.Id == result.ServiceDepotId).FirstOrDefault()
                ?.Value;
            return result;
        }

        public async Task SaveAsync(ApplyForVehicleMaintenanceEditDto input)
        {
            var item = input.MapTo<ApplyForVehicleMaintenance>();
            if (!input.Id.HasValue)
            {
                item.Code = GetMaxCode();
                await this._applyForVehicleMaintenanceRepository.InsertAsync(item);
            }
            else
            {
                var old = this._applyForVehicleMaintenanceRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._applyForVehicleMaintenanceRepository.UpdateAsync(old);
            }
        }

        public void Auding(KeyValue<Guid, int, string> input)
        {
            var item = this._applyForVehicleMaintenanceRepository.Get(input.Key);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不能为空");
            }

            item.Status = input.Value;
            item.Note2  = input.Item3;
            this._applyForVehicleMaintenanceRepository.Update(item);

            if (item.Status==VehicleMaintenanceStatus.Approved)
            {
                var clzk = this._sysDictionaryRepository.Get(r => r.Category == DictionaryCategory.Car_Status)
                    .First(r => r.Value                                      == "修理中");
                this._carInfoRepository.Update(item.CarInfoId, r => r.ClzkId = clzk.Id);
            }
        }

        public void Delete(Guid id)
        {
            this._applyForVehicleMaintenanceRepository.Delete(id);
        }

        public void SaveNote3(KeyValue<Guid, string, string> input)
        {
            var item = this._applyForVehicleMaintenanceRepository.Get(input.Key);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不能为空");
            }

            item.Note3      = input.Value;
            item.RepairType = input.Item3;
            this._applyForVehicleMaintenanceRepository.Update(item);
        }

        public void Update2(ApplyForVehicleMaintenanceUpdateDto input)
        {
            var item = this._applyForVehicleMaintenanceRepository.Get(input.Id);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不能为空");
            }

            item.Status     = VehicleMaintenanceStatus.Serviced;
            item.TotalPrice = input.Total;

            foreach (var r1 in input.ManHour)
            {
                var r = this._manHourRepository.FirstOrDefault(r1.RowId.Value);
                if (r != null)
                {
                    r.Hours2 = r1.Hours2.Value;
                    this._manHourRepository.Update(r);
                }
            }

            foreach (var r2 in input.Materials)
            {
                var r = this._servicingMaterialRepository.FirstOrDefault(r2.RowId.Value);
                if (r != null)
                {
                    r.Amount2 = r2.Amount2.Value;
                    this._servicingMaterialRepository.Update(r);
                }
            }

            this._applyForVehicleMaintenanceRepository.Update(item);
            this._repairCostRepository.Insert(new RepairCost()
            {
                ApplyForVehicleMaintenanceId = item.Id,
                Category                     = item.RepairType,
                Cost                         = input.Total,
                Year                         = item.CreationTime.Year
            });

            var repairTimes = this._carRepairTimeRepository
                .GetAllList(r => r.ApplyForVehicleMaintenanceId == item.Id);
            foreach (var repairTime in repairTimes)
            {
                repairTime.DateTo = DateTime.Today;
                repairTime.Hours = item.ManHours
                    .First(r => r.PartId == repairTime.PartId && r.ManHourId == repairTime.ManHourId).Hours2;
                this._carRepairTimeRepository.Update(repairTime);
            }
        }

        public void Update(ApplyForVehicleMaintenanceUpdateDto input)
        {
            var item = this._applyForVehicleMaintenanceRepository.Get(input.Id);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不能为空");
            }

            this._maintenanceDeliveryRepository.Delete(r => r.ApplyForVehicleMaintenanceId == item.Id);
            this._manHourRepository.Delete(r => r.ApplyForVehicleMaintenanceId             == item.Id);
            this._servicingMaterialRepository.Delete(r => r.ApplyForVehicleMaintenanceId   == item.Id);
            item.Status = VehicleMaintenanceStatus.Servicing;
            var manHours = input.ManHour.MapTo<List<ManHour>>();
            manHours.ForEach(r => r.ApplyForVehicleMaintenanceId = item.Id);
            var servicingMaterials = input.Materials.MapTo<List<ServicingMaterial>>();
            servicingMaterials.ForEach(r => r.ApplyForVehicleMaintenanceId = item.Id);
            var maintenanceDeliveries = input.Deliveries.MapTo<List<MaintenanceDelivery>>();
            maintenanceDeliveries.ForEach(r => r.ApplyForVehicleMaintenanceId = item.Id);
            this._maintenanceDeliveryRepository.InsertRange(maintenanceDeliveries);
            this._manHourRepository.InsertRange(manHours);
            this._servicingMaterialRepository.InsertRange(servicingMaterials);
            this._applyForVehicleMaintenanceRepository.Update(item);

            var repairTimes = new List<CarRepairTime>();
            foreach (var m in input.ManHour)
            {
                var repair = new CarRepairTime()
                {
                    ApplyForVehicleMaintenanceId = item.Id,
                    CatInfoId                    = item.CarInfoId,
                    PartId = m.PartId,
                    DateFrom = item.LastModificationTime.Value,
                    ManHourId = m.ManHourId,
                    ServiceDepotId = item.ServiceDepotId
                };
                repairTimes.Add(repair);
            }

            this._carRepairTimeRepository.InsertRange(repairTimes);
        }

        public ApplyForVehicleMaintenanceUpdateDto GetClosingItem(Guid id)
        {
            var item = this._applyForVehicleMaintenanceRepository.Get(id);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不存在");
            }

            var result = item.MapTo<ApplyForVehicleMaintenanceUpdateDto>();
            foreach (var dto in result.ManHour)
            {
                dto.PartName     = this._layerRepository.Get(dto.PartId)?.Name;
                dto.ManHourName  = this._sysDictionaryRepository.Get(dto.ManHourId).Value;
                dto.ManHourValue = decimal.Parse(this._sysDictionaryRepository.Get(dto.ManHourId).Value3);
                dto.Hours2       = dto.Hours1;
            }

            foreach (var dto in result.Materials)
            {
                dto.Amount2       = dto.Amount1;
                dto.PartName      = this._layerRepository.Get(dto.PartId)?.Name;
                dto.MaterialName  = this._sysDictionaryRepository.Get(dto.MaterialId).Value;
                dto.MaterialValue = decimal.Parse(this._sysDictionaryRepository.Get(dto.MaterialId).Value3);
            }

            foreach (var dto in result.Deliveries)
            {
                var d = this._deliveryRepository.Get(dto.Id);
                dto.Code   = d.Product.Code;
                dto.Amount = d.Amount;
                dto.Name   = d.Product.Name;
                dto.Price  = d.Price;
            }

            return result;
        }

        /// <summary>
        /// 获取年度/季度维修情况报告
        /// </summary>
        /// <param name="quarter"></param>
        public List<VehicleMaintenanceReportDto> GetReport(int quarter)
        {
            var result   = new List<VehicleMaintenanceReportDto>();
            var year     = DateTime.Today.Year;
            var dateFrom = new DateTime(year, 1, 1);
            var dateTo   = dateFrom;
            switch (quarter)
            {
                case 0:
                    dateTo = new DateTime(year, 4, 1);
                    break;
                case 1:
                    dateTo = new DateTime(year, 7, 1);
                    break;
                case 2:
                    dateTo = new DateTime(year, 10, 1);
                    break;
                case 3:
                    dateTo = new DateTime(year + 1, 1, 1);
                    break;
            }

            var query = this._applyForVehicleMaintenanceRepository.GetAllList(
                r => r.CreationTime >= dateFrom && r.CreationTime < dateTo &&
                     r.Status       == VehicleMaintenanceStatus.Serviced);
            foreach (var item in query)
            {
                var resultItem = new VehicleMaintenanceReportDto()
                {
                    Code  = item.Code,
                    Id    = item.Id,
                    Cph   = item.CarInfo.Cph,
                    Note  = item.Note,
                    Zbsj  = item.CarInfo.Zbsj.ToString("yyyy-MM-dd"),
                    Ysclf = 0,
                    Sjclf = 0,
                    Ysgsf = 0,
                    Sjgsf = 0,
                    Zyclf = 0
                };

                foreach (var material in item.ServicingMaterials)
                {
                    var dic = this._sysDictionaryRepository.Get(material.MaterialId);
                    if (dic == null)
                    {
                        throw new UserFriendlyException("维修材料不能为空");
                    }

                    resultItem.Ysclf += decimal.Parse(dic.Value3) * material.Amount1;
                    resultItem.Sjclf += decimal.Parse(dic.Value3) * material.Amount2;
                }

                foreach (var material in item.ManHours)
                {
                    var dic = this._sysDictionaryRepository.Get(material.ManHourId);
                    if (dic == null)
                    {
                        throw new UserFriendlyException("工时不能为空");
                    }

                    resultItem.Ysgsf += decimal.Parse(dic.Value3) * material.Hours1;
                    resultItem.Sjgsf += decimal.Parse(dic.Value3) * material.Hours2;
                }

                foreach (var material in item.MaintenanceDeliveries)
                {
                    var dic = this._deliveryRepository.Get(material.DeliveryId);
                    if (dic == null)
                    {
                        throw new UserFriendlyException("出库单不能为空");
                    }

                    resultItem.Zyclf += dic.Amount * dic.Price;
                }

                result.Add(resultItem);
            }

            return result;
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this._applyForVehicleMaintenanceRepository.Get(r => r.Code.StartsWith("SXD" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"SXD{preCode}001";
            }
            else
            {
                return $"SXD{(long.Parse(maxCode.Substring(3)) + 1):000}";
            }
        }
    }
}
