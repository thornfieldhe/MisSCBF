// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单服务
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
    /// 出库单服务
    /// </summary>
    [AbpAuthorize]
    public class DeliveryBillAppService : TAFAppServiceBase, IDeliveryBillAppService
    {
        private readonly IDeliveryBillRepository deliveryBillRepository;
        private readonly IStockRepository stockRepository;

        public DeliveryBillAppService(IDeliveryBillRepository deliveryBillRepository, IStockRepository stockRepository)
        {
            this.deliveryBillRepository = deliveryBillRepository;
            this.stockRepository = stockRepository;
        }

        public StockBillEditDto New()
        {
            return new StockBillEditDto { Code = this.GetMaxCode(), Id = Guid.NewGuid() };
        }

        public async Task SaveAsync(StockBillEditDto input)
        {
            var item = input.MapTo<DeliveryBill>();
            item.Deliveries.ForEach(r => r.DeliveryBillId = item.Id);
            if (!this.deliveryBillRepository.Any(r => r.Id == input.Id))
            {
                item.Code = this.GetMaxCode();
                item = await this.deliveryBillRepository.InsertAsync(item);
            }
            else
            {
                var old = this.deliveryBillRepository.Get(input.Id);
                Mapper.Map(input, old);
                item = await this.deliveryBillRepository.UpdateAsync(old);
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
                this.deliveryBillRepository.Get(r => r.Code.StartsWith("CK" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"CK{preCode}001";
            }
            else
            {
                return $"CK{long.Parse(maxCode.Substring(2)) + 1}";
            }
        }
    }
}



