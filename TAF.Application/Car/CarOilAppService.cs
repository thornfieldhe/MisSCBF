// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.UI;
using SCBF.BaseInfo;
using TAF.Utility;

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
    using SCBF.Car.Dto;

    /// <inheritdoc />
    /// <summary>
    /// 车辆油料核算表服务
    /// </summary>
    [AbpAuthorize]
    public class CarOilAppService : TAFAppServiceBase, ICarOilAppService
    {
        private readonly ICarOilRepository _carOilRepository;
        private readonly IUploadOilCarRoofRelationshipRepository _uploadOilCarRoofRelationshipRepository;
        private readonly IUploadOilCardRoofRepository _uploadOilCardRoofRepository;
        private readonly ICarInfoRepository _carInfoRepository;
        private readonly IOilCardRepository _oilCardRepository;
        private readonly IApplicationForBunkerBRepository _applicationForBunkerBRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;

        public CarOilAppService(ICarOilRepository carOilRepository,
            IUploadOilCarRoofRelationshipRepository uploadOilCarRoofRelationshipRepositor,
            IUploadOilCardRoofRepository uploadOilCardRoofRepository,
            ICarInfoRepository carInfoRepository,
            IOilCardRepository oilCardRepository,
            IApplicationForBunkerBRepository applicationForBunkerBRepository,
            ISysDictionaryRepository sysDictionaryRepository)
        {
            this._carOilRepository = carOilRepository;
            this._uploadOilCarRoofRelationshipRepository = uploadOilCarRoofRelationshipRepositor;
            this._uploadOilCardRoofRepository = uploadOilCardRoofRepository;
            this._carInfoRepository = carInfoRepository;
            this._oilCardRepository = oilCardRepository;
            this._applicationForBunkerBRepository = applicationForBunkerBRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<CarOilListDto> GetAll(CarOilQueryDto request)
        {
            var query = this._carOilRepository.GetAll()

                .WhereIf(request.CarInfoId.HasValue, r => r.CarInfoId == request.CarInfoId.Value)
                .WhereIf(request.Year.HasValue, r => r.Year == request.Year.Value)
                .WhereIf(request.Month.HasValue, r => r.Month == request.Month.Value);

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

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(Guid id)
        {
            this._carOilRepository.Delete(id);
        }

        /// <summary>
        /// The get report.
        /// </summary>
        /// <param name="ym">
        /// The ym.
        /// </param>
        /// <returns>
        /// The Result
        /// </returns>
        /// <exception cref="UserFriendlyException">
        /// </exception>
        public List<CarOilReportDto> GetReport(KeyValue<int, int> ym)
        {
            var summary =
                this._sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Car_OilWearSummary);
            if (summary == null)
            {
                throw new UserFriendlyException("未指定夏季起止时间");
            }
            var summaryFrom = int.Parse(summary.Value);
            var summaryTo = int.Parse(summary.Value2);
            var isInSummary = ym.Key >= summaryFrom && ym.Value <= summaryTo;

            var yearmonth = $"{ym.Key}{ym.Value:00}";
            var result = new List<CarOilReportDto>();
            var list1 = from a in this._uploadOilCarRoofRelationshipRepository.GetAll()
                        join b in this._uploadOilCardRoofRepository.GetAll() on a.RId equals b.Id
                        join c in this._oilCardRepository.GetAll() on b.CarCode equals c.Code
                        join d in this._carInfoRepository.GetAll() on c.CarInfoId equals d.Id
                        where a.Month == yearmonth
                        select new KeyValue<Guid, decimal>
                        {
                            Key = d.Id,
                            Value = b.Amount,
                        };
            var list2 = this._applicationForBunkerBRepository.GetAll().Where(a => a.LastModificationTime.Value.Year == ym.Key && a.LastModificationTime.Value.Month == ym.Value && a.Status == ApplicationForBunkerAStatus.Checked)
                .Select(r => new KeyValue<Guid, decimal>
                {
                    Key = r.CarInfoId,
                    Value = r.AuditingAmount
                });
            var li = list1.ToList();
            li.AddRange(list2);
            var list3 = from l in li
                        group l by l.Key
                into m
                        select new KeyValue<Guid, decimal> { Key = m.Key, Value = m.Sum(r => r.Value) };
            var yearMonthFrom = new DateTime(ym.Key, ym.Value, 1).AddMonths(-1);
            foreach (var item in list3)
            {
                var carInfo = this._carInfoRepository.FirstOrDefault(r => r.Id == item.Key);
                if (carInfo != null)
                {
                    var carOilFrom = this._carOilRepository.FirstOrDefault(
                        r => r.Month == yearMonthFrom.Month && r.Year == yearMonthFrom.Year && r.CarInfoId == carInfo.Id);
                    var carOilTo = this._carOilRepository.FirstOrDefault(
                        r => r.Year == ym.Key && r.Month == ym.Value && r.CarInfoId == carInfo.Id);
                    if (carOilTo == null)
                    {
                        throw new UserFriendlyException("未录入当月剩余油料");
                    }

                    result.Add(new CarOilReportDto()
                    {
                        Cph = carInfo.Cph,
                        ActualOilWear = item.Value + (carOilFrom == null ? 0 : carOilFrom.Amount) - carOilTo.Amount,
                        ExpectOilWear = isInSummary ? (carInfo.OilWearSummer ?? 0) : (carInfo.OilWearWinter ?? 0),
                        YearMonth = $"{ym.Key}-{ym.Value}",
                    });
                }
            }

            return result;
        }
    }
}



