// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using SCBF.BaseInfo.Dto;
    using SCBF.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using Abp.UI;

    using SCBF.BaseInfo;
    using SCBF.Storage.Dto;

    using TAF.Utility;

    /// <summary>
    /// 历史库存服务
    /// </summary>
    [AbpAuthorize]
    public class HisStockAppService : TAFAppServiceBase, IHisStockAppService
    {
        private readonly IHisStockRepository hisStockRepository;
        private readonly IStockRepository stockRepository;
        private readonly IDeliveryBillRepository deliveryBillRepository;
        private readonly IEntryBillRepository entryBillRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public HisStockAppService(IHisStockRepository hisStockRepository
            , IStockRepository stockRepository
            , IDeliveryBillRepository deliveryBillRepository
            , IEntryBillRepository entryBillRepository
            , ISysDictionaryRepository sysDictionaryRepository)
        {
            this.hisStockRepository = hisStockRepository;
            this.stockRepository = stockRepository;
            this.entryBillRepository = entryBillRepository;
            this.deliveryBillRepository = deliveryBillRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<HisStockListDto> GetAll(HisStockQueryDto request)
        {
            var query = this.hisStockRepository.GetAll()

                .WhereIf(request.ProductId.HasValue, r => r.ProductId == request.ProductId.Value)
                .WhereIf(request.Amount.HasValue, r => r.Amount == request.Amount.Value)
                .WhereIf(request.Price.HasValue, r => r.Price == request.Price.Value)
                .WhereIf(request.StorageId.HasValue, r => r.StorageId == request.StorageId.Value)
                .WhereIf(request.DateFrom.HasValue, r => r.Date >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.Date <= request.DateTo.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<HisStockListDto>>();

            return new PagedResultDto<HisStockListDto>(count, dtos);
        }


        public List<HisStockReportListDto> GetHistory(int quarter)
        {
            var defaultYear =
                   this.sysDictionaryRepository.FirstOrDefault(
                       r => r.Category == DictionaryCategory.Material_Year && r.Value4 == true.ToString());
            if (defaultYear == null)
            {
                throw new UserFriendlyException("会计年度不存在");
            }
            var year = defaultYear.Value.ToInt();
            var dtFrom = new DateTime(year, 1, 1);
            var dtTo = new DateTime(year, 3, 31);

            switch (quarter)
            {
                case 1:
                    dtTo = new DateTime(year, 6, 30);
                    break;
                case 2:
                    dtTo = new DateTime(year, 9, 30);
                    break;
                case 3:
                    dtTo = new DateTime(year, 12, 31);
                    break;
            }

            var initialDate = dtFrom.AddDays(-1);
            var endDate = dtTo.AddDays(1);
            var initialNumbers = this.hisStockRepository.Get(r => r.Date == initialDate).MapTo<List<HisStockReportListDto>>();
            var addNumbers = this.deliveryBillRepository.Get(r => r.CreationTime >= dtFrom && r.CreationTime < endDate).MapTo<List<HisStockReportListDto>>();
            var reduceNumbers = this.entryBillRepository.Get(r => r.CreationTime >= dtFrom && r.CreationTime < endDate).MapTo<List<HisStockReportListDto>>();
            var endNumbers = this.hisStockRepository.Get(r => r.Date == endDate).MapTo<List<HisStockReportListDto>>();
            endNumbers.ForEach(
                item =>
                    {
                        item.Price3 = item.Price1;
                        item.Amount3 = item.Amount1;
                        item.Total3 = item.Total1;
                        item.Price1 = string.Empty;
                        item.Amount1 = string.Empty;
                        item.Total1 = string.Empty;

                    });
            var result = new List<HisStockReportListDto>();
            result.AddRange(initialNumbers);
            result.AddRange(addNumbers);
            result.AddRange(reduceNumbers);
            result.AddRange(endNumbers);
            return result.OrderBy(r => r.Date).ToList();
        }

        public void BackupData()
        {
            var date = DateTime.Today.AddDays(-1);
            var stocks =
                this.stockRepository.Get(
                        r => r.CreationTime >= date && r.CreationTime < DateTime.Today)
                    .ToList()
                    .MapTo<List<HisStock>>();
            this.hisStockRepository.InsertRange(stocks);
        }
    }
}