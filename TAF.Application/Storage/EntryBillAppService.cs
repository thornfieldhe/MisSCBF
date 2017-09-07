// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using SCBF.Storage.Dto;

    /// <summary>
    /// 入库单服务
    /// </summary>
    [AbpAuthorize]
    public class EntryBillAppService : TAFAppServiceBase, IEntryBillAppService
    {
        private readonly IEntryBillRepository entryBillRepository;
        private readonly IEntryRepository entryRepository;
        private readonly IStockRepository stockRepository;

        public EntryBillAppService(IEntryBillRepository entryBillRepository
            , IEntryRepository entryRepository
            , IStockRepository stockRepository)
        {
            this.entryBillRepository = entryBillRepository;
            this.stockRepository = stockRepository;
            this.entryRepository = entryRepository;
        }

        public StockBillEditDto New()
        {
            return new StockBillEditDto { Code = this.GetMaxCode(), Id = Guid.NewGuid() };
        }

        public async Task<List<ProductStockListDto>> SaveAsync(StockBillEditDto input)
        {
            var item = input.MapTo<EntryBill>();
            item.Entries.ForEach(r => r.EntryBillId = item.Id);

            item.Code = this.GetMaxCode();
            await this.entryBillRepository.InsertAsync(item);

            // 更新库存信息
            foreach (var entry in input.Items)
            {
                var stock = new Stock()
                {
                    Amount = entry.Amount,
                    ProductId = entry.ProductId,
                    StorageId = entry.StorageId,
                    Price = entry.Price
                };
                await this.stockRepository.InsertAsync(stock);
            }
            this.CurrentUnitOfWork.SaveChanges();
            return this.entryRepository.GetAllIncluding(r => r.Product, r => r.Storage).Where(r => r.EntryBillId == item.Id).ToList().MapTo<List<ProductStockListDto>>();
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.entryBillRepository.Get(r => r.Code.StartsWith("RK" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"RK{preCode}001";
            }
            else
            {
                return $"RK{(long.Parse(maxCode.Substring(2)) + 1):000}";
            }
        }
    }
}



