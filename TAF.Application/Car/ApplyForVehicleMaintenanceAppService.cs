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
        private readonly IApplyForVehicleMaintenanceRepository _applyForVehicleMaintenanceRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IMaintenanceDeliveryRepository _maintenanceDeliveryRepository;
        private readonly IServicingMaterialRepository _servicingMaterialRepository;
        private readonly IManHourRepository _manHourRepository;
        private readonly ILayerRepository _layerRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IRepairCostRepository _repairCostRepository;

        public ApplyForVehicleMaintenanceAppService(
            IApplyForVehicleMaintenanceRepository applyForVehicleMaintenanceRepository,
                                                    IDriverRepository driverRepository,
            IMaintenanceDeliveryRepository maintenanceDeliveryRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IRepairCostRepository repairCostRepository,
        ILayerRepository layerRepository,
            IDeliveryRepository deliveryRepository,
        IServicingMaterialRepository servicingMaterialRepository,
            IManHourRepository manHourRepository
            )
        {
            this._applyForVehicleMaintenanceRepository = applyForVehicleMaintenanceRepository;
            this._deliveryRepository = deliveryRepository;
            this._driverRepository = driverRepository;
            this._layerRepository = layerRepository;
            this._repairCostRepository = repairCostRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
            this._maintenanceDeliveryRepository = maintenanceDeliveryRepository;
            this._servicingMaterialRepository = servicingMaterialRepository;
            this._manHourRepository = manHourRepository;
        }

        public ListResultDto<ApplyForVehicleMaintenanceListDto> GetAll(ApplyForVehicleMaintenanceQueryDto request)
        {
            var query = this._applyForVehicleMaintenanceRepository.GetAll()

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
                var driver = this._driverRepository.Get(dto.DriverId);
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

        public PagedResultDto<ApplyForVehicleMaintenanceListDto> GetAuditedItems(ApplyForVehicleMaintenanceQueryDto request)
        {
            var query = this._applyForVehicleMaintenanceRepository.GetAll()
                .Where(r => r.Status == request.Status.Value).OrderByDescending(r => r.CreationTime);

            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ApplyForVehicleMaintenanceListDto>>();
            foreach (var dto in dtos)
            {
                var driver = this._driverRepository.Get(dto.DriverId);
                if (driver == null)
                {
                    throw new UserFriendlyException("驾驶员不能为空");
                }
                dto.DriverName = driver.Name;
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
            item.Note2 = input.Item3;
            this._applyForVehicleMaintenanceRepository.Update(item);
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
            item.Note3 = input.Value;
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

            item.Status = VehicleMaintenanceStatus.Serviced;
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
                Category = item.RepairType,
                Cost = input.Total,
                Year = item.CreationTime.Year
            });
        }

        public void Update(ApplyForVehicleMaintenanceUpdateDto input)
        {
            var item = this._applyForVehicleMaintenanceRepository.Get(input.Id);
            if (item == null)
            {
                throw new UserFriendlyException("车辆送修申请单不能为空");
            }

            this._maintenanceDeliveryRepository.Delete(r => r.ApplyForVehicleMaintenanceId == item.Id);
            this._manHourRepository.Delete(r => r.ApplyForVehicleMaintenanceId == item.Id);
            this._servicingMaterialRepository.Delete(r => r.ApplyForVehicleMaintenanceId == item.Id);


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
                dto.PartName = this._layerRepository.Get(dto.PartId)?.Name;
                dto.ManHourName = this._sysDictionaryRepository.Get(dto.ManHourId).Value;
                dto.ManHourValue = decimal.Parse(this._sysDictionaryRepository.Get(dto.ManHourId).Value3);
                dto.Hours2 = dto.Hours1;
            }
            foreach (var dto in result.Materials)
            {
                dto.Amount2 = dto.Amount1;
                dto.PartName = this._layerRepository.Get(dto.PartId)?.Name;
                dto.MaterialName = this._sysDictionaryRepository.Get(dto.MaterialId).Value;
                dto.MaterialValue = decimal.Parse(this._sysDictionaryRepository.Get(dto.MaterialId).Value3);
            }
            foreach (var dto in result.Deliveries)
            {
                var d = this._deliveryRepository.Get(dto.Id);
                dto.Code = d.Product.Code;
                dto.Amount = d.Amount;
                dto.Name = d.Product.Name;
                dto.Price = d.Price;
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
                return $"SXD{long.Parse(maxCode.Substring(3)) + 1}";
            }
        }
    }
}



