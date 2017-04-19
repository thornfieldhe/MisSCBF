﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;

    using AutoMapper;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 入库单服务
    /// </summary>
    [AbpAuthorize]
    public class EntryBillAppService : TAFAppServiceBase, IEntryBillAppService
    {
        private readonly IEntryBillRepository entryBillRepository;
        private readonly IStockRepository stockRepository;

        public EntryBillAppService(IEntryBillRepository entryBillRepository, IStockRepository stockRepository)
        {
            this.entryBillRepository = entryBillRepository;
            this.stockRepository = stockRepository;
        }

        public StockBillEditDto New()
        {
            return new StockBillEditDto { Code = this.GetMaxCode(), Id = Guid.NewGuid() };
        }

        public async Task SaveAsync(StockBillEditDto input)
        {
            var item = input.MapTo<EntryBill>();
            item.Entries.ForEach(r => r.EntryBillId = item.Id);
            if (!this.entryBillRepository.Any(r => r.Id == input.Id))
            {
                item.Code = this.GetMaxCode();
                item = await this.entryBillRepository.InsertAsync(item);
            }
            else
            {
                var old = this.entryBillRepository.Get(input.Id);
                Mapper.Map(input, old);
                item = await this.entryBillRepository.UpdateAsync(old);
            }

            // 更新库存信息
            foreach (var entry in input.Items)
            {
                var productInStock = this.stockRepository.FirstOrDefault(r => r.ProductId == entry.ProductId && r.StorageId == entry.StorageId);
                if (productInStock == null)
                {
                    var stock = new Stock()
                    {
                        Amount = entry.Amount,
                        ProductId = entry.ProductId,
                        StorageId = entry.StorageId
                    };
                    await this.stockRepository.InsertAsync(stock);
                }
                else
                {
                    productInStock.Amount += entry.Amount;
                    await this.stockRepository.UpdateAsync(productInStock);
                }
            }

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
                return $"RK{long.Parse(maxCode.Substring(2)) + 1}";
            }
        }
    }
}


