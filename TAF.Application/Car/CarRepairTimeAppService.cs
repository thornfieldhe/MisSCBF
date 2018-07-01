// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarRepairTimeAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TAF.Utility;

namespace SCBF.Car
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using Abp.Authorization;
    using SCBF.Car.Dto;

    /// <summary>
    /// 车辆维修耗时管理服务
    /// </summary>
    [AbpAuthorize]
    public class CarRepairTimeAppService : TAFAppServiceBase, ICarRepairTimeAppService
    {
        private readonly ICarRepairTimeRepository _carRepairTimeRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;

        public CarRepairTimeAppService(ICarRepairTimeRepository carRepairTimeRepository,
            ISysDictionaryRepository                            sysDictionaryRepository)
        {
            this._carRepairTimeRepository = carRepairTimeRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }

        public List<CarRepairTimeListDto> GetAll(CarRepairTimeQueryDto request)
        {
            var query = this._carRepairTimeRepository.GetAllList(r => r.DateTo.HasValue
                                                                      && r.DateTo >= request.DateFrom
                                                                      && r.DateTo <= request.DateTo);
            var services = query.Select(r => r.ServiceDepotId).Distinct().ToList();
            var result   = new List<CarRepairTimeListDto>();
            foreach (var service in services)
            {
                var items = query.Where(r => r.ServiceDepotId == service);
                var dto = new CarRepairTimeListDto()
                {
                    ServiceDepot = this._sysDictionaryRepository.Get(service).Value
                };
                var dic = new List<KeyValue<Guid, Guid, DateTime, int>>();
                foreach (var item in items)
                {
                    var p = dic.FirstOrDefault(r =>
                        r.Key == item.CatInfoId && r.Value == item.PartId && r.Item3 == item.DateTo.Value);
                    if (p == null)
                    {
                        dic.Add(new KeyValue<Guid, Guid, DateTime, int>(item.CatInfoId, item.PartId, item.DateTo.Value,
                            1));
                    }
                    else
                    {
                        p.Item4 += 1;
                    }
                }

                // 维修厂累计维修次数
                var total = dic.Count;
                foreach (var d in dic)
                {
                    d.Item4 -= 1;
                }

                dto.Value1 = (100M*dic.Sum(r => r.Item4) / total).ToString("F0");


                var dic2 = new List<KeyValue<Guid,decimal,decimal>>();
                foreach (var item in items)
                {
                    var p = dic2.FirstOrDefault(r =>
                        r.Key == item.ApplyForVehicleMaintenanceId);
                    if (p == null)
                    {
                        dic2.Add(new KeyValue<Guid, decimal,decimal>(item.ApplyForVehicleMaintenanceId, item.Hours,0M));
                    }
                    else
                    {
                        p.Value += item.Hours;
                    }
                }

                // 维修单累计维修工时
                var value2 = 0;
                foreach (var d in dic2)
                {
                    var v = items.First(r => r.ApplyForVehicleMaintenanceId == d.Key);
                    d.Item3 =decimal.Parse(v.DateTo.Value.Subtract(v.DateFrom).TotalHours.ToString("F2"));

                }

                dto.Value2 = (dic2.Sum(r => r.Item3) -dic2.Sum(r => r.Value) *24).ToString("F0");

                result.Add(dto);
            }

            return result;
        }

    }
}


