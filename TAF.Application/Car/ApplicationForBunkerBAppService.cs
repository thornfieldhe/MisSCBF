// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerBAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料加油审批单服务
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
    using SCBF.BaseInfo;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    /// <summary>
    /// 实物油料加油审批单服务
    /// </summary>
    [AbpAuthorize]
    public class ApplicationForBunkerBAppService : TAFAppServiceBase, IApplicationForBunkerBAppService
    {
        private readonly IApplicationForBunkerBRepository applicationForBunkerBRepository;
        private readonly IOctaneStoreRepository octaneStoreRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IHisStoreStockAppService hisStoreStockAppService;

        public ApplicationForBunkerBAppService(IApplicationForBunkerBRepository applicationForBunkerBRepository,
                                               IOctaneStoreRepository octaneStoreRepository,
                                               ISysDictionaryRepository sysDictionaryRepository,
                                               IHisStoreStockAppService hisStoreStockAppService)
        {
            this.applicationForBunkerBRepository = applicationForBunkerBRepository;
            this.octaneStoreRepository = octaneStoreRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.hisStoreStockAppService = hisStoreStockAppService;
        }

        public ListResultDto<ApplicationForBunkerBListDto> GetAll(ApplicationForBunkerBQueryDto request)
        {
            var query = this.applicationForBunkerBRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.Code.Contains(request.Code))
                .WhereIf(request.OctaneStoreId.HasValue, r => r.OctaneStoreId == request.OctaneStoreId.Value)
                .WhereIf(request.DriverId.HasValue, r => r.DriverId == request.DriverId.Value)
                .WhereIf(request.DateFrom.HasValue, r => r.Date >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.Date <= request.DateTo.Value)
                .WhereIf(request.Status.HasValue, r => (int)r.Status == request.Status.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Code);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ApplicationForBunkerBListDto>>();

            var store = from s in this.octaneStoreRepository.GetAll()
                        join a in this.sysDictionaryRepository.GetAll() on s.StoreId equals a.Id
                        join b in this.sysDictionaryRepository.GetAll() on s.OctaneRatingId equals b.Id
                        select new TAF.Utility.KeyValue<string, Guid>() { Key = a.Value + "-" + b.Value, Value = s.Id };
            foreach (var item in dtos)
            {
                switch (item.Status)
                {
                    case "0":
                        item.Status = "等待审核";
                        break;
                    case "1":
                        item.Status = "审核通过";
                        break;
                    case "2":
                        item.Status = "审核拒绝";
                        break;
                    case "5":
                        item.Status = "已对账";
                        break;
                }
                item.OctaneStoreName = store.First(r => r.Value == item.OctaneStoreId).Key;
            }

            return new PagedResultDto<ApplicationForBunkerBListDto>(count, dtos);
        }

        public ApplicationForBunkerBEditDto Get(Guid id)
        {
            var output = this.applicationForBunkerBRepository.Get(id);
            var result = output.MapTo<ApplicationForBunkerBEditDto>();

            var store = from s in this.octaneStoreRepository.GetAll()
                        join a in this.sysDictionaryRepository.GetAll() on s.StoreId equals a.Id
                        join b in this.sysDictionaryRepository.GetAll() on s.OctaneRatingId equals b.Id
                        select new TAF.Utility.KeyValue<string, Guid>() { Key = a.Value + "-" + b.Value, Value = s.Id };
            result.OctaneStoreName = store.First(r => r.Value == result.OctaneStoreId).Key;
            return result;
        }

        public async Task SaveAsync(ApplicationForBunkerBEditDto input)
        {
            var item = input.MapTo<ApplicationForBunkerB>();
            if (!input.Id.HasValue)
            {
                item.Date = string.IsNullOrWhiteSpace(input.Date) ? DateTime.Now : DateTime.Parse(input.Date);
                item.Code = GetMaxCode();
                item.Status = ApplicationForBunkerAStatus.Pending;
                await this.applicationForBunkerBRepository.InsertAsync(item);
            }
            else
            {
                var old = this.applicationForBunkerBRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.applicationForBunkerBRepository.UpdateAsync(old);
                if (item.Status == ApplicationForBunkerAStatus.Approved)
                {
                    var card = this.octaneStoreRepository.FirstOrDefault(r => r.Id == input.OctaneStoreId);
                    if (card == null)
                    {
                        throw new UserFriendlyException("实物油料不存在");
                    }

                    card.Amount -= input.AuditingAmount;
                    this.octaneStoreRepository.Update(card);
                }
            }
        }

        public void Check(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var item = this.applicationForBunkerBRepository.Get(id);
                if (item == null)
                {
                    throw new UserFriendlyException("加油申请不存在");
                }

                item.Status = ApplicationForBunkerAStatus.Checked;
                this.applicationForBunkerBRepository.Update(item);
            }
        }
        public void Delete(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var item = this.applicationForBunkerBRepository.Get(id);
                if (item == null)
                {
                    throw new UserFriendlyException("加油申请不存在");
                }

                var store = this.octaneStoreRepository.FirstOrDefault(r => r.Id == item.OctaneStoreId);
                if (store == null)
                {
                    throw new UserFriendlyException("实物油料库存不存在");
                }
                store.Amount += item.AuditingAmount;
                this.octaneStoreRepository.Update(store);
                this.applicationForBunkerBRepository.Delete(id);
            }
        }

        public List<ApplicationForBunkerBListDto> CheckApplicationForBunkerBList(string queryMonth)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var month = int.Parse(queryMonth);
            var query = this.applicationForBunkerBRepository.GetAll().Where(r => r.Date.Year == year && r.Date.Month == month && r.Status == 1);


            var store = from s in this.octaneStoreRepository.GetAll()
                        join a in this.sysDictionaryRepository.GetAll() on s.StoreId equals a.Id
                        join b in this.sysDictionaryRepository.GetAll() on s.OctaneRatingId equals b.Id
                        select new TAF.Utility.KeyValue<string, Guid>() { Key = a.Value + "-" + b.Value, Value = s.Id };

            var dtos = query.MapTo<List<ApplicationForBunkerBListDto>>();


            foreach (var item in dtos)
            {
                item.OctaneStoreName = store.First(r => r.Value == item.OctaneStoreId).Key;
            }

            return new List<ApplicationForBunkerBListDto>(dtos);
        }

        public List<ApplicationForBunkerBListDto> GetApplicationForBunkerBSummaryList(string queryMonth)
        {
            var currentYearItem = this.sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Car_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var month = int.Parse(queryMonth);
            var query = this.applicationForBunkerBRepository.GetAll().Where(r => r.Date.Year == year && r.Date.Month == month && r.Status == ApplicationForBunkerAStatus.Checked);


            var store = from s in this.octaneStoreRepository.GetAll()
                        join a in this.sysDictionaryRepository.GetAll() on s.StoreId equals a.Id
                        join b in this.sysDictionaryRepository.GetAll() on s.OctaneRatingId equals b.Id
                        select new TAF.Utility.KeyValue<string, Guid>() { Key = a.Value + "-" + b.Value, Value = s.Id };

            var dtos = query.MapTo<List<ApplicationForBunkerBListDto>>();


            foreach (var item in dtos)
            {
                item.OctaneStoreName = store.First(r => r.Value == item.OctaneStoreId).Key;
                var amount = this.hisStoreStockAppService.Get(month, 1);
                item.AmountFrom = amount.Key;
                item.AmountTo = amount.Value;
            }

            return new List<ApplicationForBunkerBListDto>(dtos);
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.applicationForBunkerBRepository.Get(r => r.Code.StartsWith("SWYL" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"SWYL{preCode}001";
            }
            else
            {
                return $"SWYL{long.Parse(maxCode.Substring(4)) + 1}";
            }
        }
    }
}



