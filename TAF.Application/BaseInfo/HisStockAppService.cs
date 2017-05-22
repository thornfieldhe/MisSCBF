// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
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

    using TAF.Utility;

    /// <summary>
    /// 历史库存服务
    /// </summary>
    [AbpAuthorize]
    public class HisStockAppService : TAFAppServiceBase, IHisStockAppService
    {
        private readonly IHisStockRepository hisStockRepository;
        private readonly IStockRepository stockRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public HisStockAppService(IHisStockRepository hisStockRepository
            , IStockRepository stockRepository
            , ISysDictionaryRepository sysDictionaryRepository)
        {
            this.hisStockRepository = hisStockRepository;
            this.stockRepository = stockRepository;
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
            var dtFrom = new DateTime(year , 1, 1);
            var dtTo = new DateTime(year, 3, 31);

            List<HisStockReportListDto> initialNumbers;
            List<HisStockReportListDto> addNumbers;
            List<HisStockReportListDto> reduceNumbers;
            List<HisStockReportListDto> endNumbers;
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
            initialNumbers = this.hisStockRepository.Get(r => r.Date == initialDate).MapTo<List<HisStockReportListDto>>();
            addNumbers = this.stockRepository.Get(r => r.CreationTime >= dtFrom && r.CreationTime < endDate).MapTo<List<HisStockReportListDto>>();
            reduceNumbers = this.stockRepository.Get(r => r.CreationTime >= dtFrom && r.CreationTime < endDate).MapTo<List<HisStockReportListDto>>();
            endNumbers = this.hisStockRepository.Get(r => r.Date == endDate).MapTo<List<HisStockReportListDto>>();
            return null;
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