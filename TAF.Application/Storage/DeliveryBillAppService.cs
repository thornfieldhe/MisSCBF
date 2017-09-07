// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;

namespace SCBF.Storage
{
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using SCBF.Storage.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TAF.Utility;

    /// <summary>
    /// 出库单服务
    /// </summary>
    [AbpAuthorize]
    public class DeliveryBillAppService : TAFAppServiceBase, IDeliveryBillAppService
    {
        private readonly IDeliveryBillRepository _deliveryBillRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryBillAppService(
            IDeliveryBillRepository deliveryBillRepository,
            IDeliveryRepository deliveryRepository, IStockRepository stockRepository)
        {
            this._deliveryBillRepository = deliveryBillRepository;
            this._stockRepository = stockRepository;
            this._deliveryRepository = deliveryRepository;
        }

        public PagedResultDto<KeyValue<Guid, string>> GetSimpleList(DeliveryBillQueryDto request)
        {
            var query = this._deliveryBillRepository.GetAllList(
                r => request.Code == null || request.Code == "" || r.Code.Contains(request.Code));
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).Select(r => new TAF.Utility.KeyValue<Guid, string> { Key = r.Id, Value = r.Code }).ToList();

            return new PagedResultDto<KeyValue<Guid, string>>(count, list);
        }

        public StockBillEditDto New()
        {
            return new StockBillEditDto { Code = this.GetMaxCode(), Id = Guid.NewGuid() };
        }

        public async Task<List<ProductStockListDto>> SaveAsync(StockBillEditDto input)
        {
            var item = input.MapTo<DeliveryBill>();
            item.Deliveries = new List<Delivery>();



            // 更新库存信息
            foreach (var entry in input.Items)
            {
                var stocks =
                    this._stockRepository.Get(
                            r => r.ProductId == entry.ProductId && r.StorageId == entry.StorageId)
                        .OrderBy(r => r.CreationTime)
                        .ToList();//获取所有行库存量
                var totalAmount = entry.Amount;
                foreach (var stock in stocks)
                {
                    if (stock.Amount > totalAmount) // 如果当前行库存量>出库量,则当前库存量=当前原库存量-出库量
                    {
                        stock.Amount -= totalAmount;
                        this._stockRepository.Update(stock);
                        item.Deliveries.Add(
                            new Delivery()
                            {
                                Amount = totalAmount,
                                ProductId = entry.ProductId,
                                DeliveryBillId = item.Id,
                                Note = entry.Note,
                                Price = stock.Price,
                                StorageId = stock.StorageId
                            });
                        totalAmount = 0;
                        break;
                    }
                    else if (stock.Amount == totalAmount) // 如果当前行库存量==出库量,则清除当前行库存
                    {
                        totalAmount = 0;
                        this._stockRepository.Delete(stock);
                        item.Deliveries.Add(
                            new Delivery()
                            {
                                Amount = totalAmount,
                                ProductId = entry.ProductId,
                                DeliveryBillId = item.Id,
                                Note = entry.Note,
                                Price = stock.Price,
                                StorageId = stock.StorageId
                            });

                        break;
                    }
                    else
                    {
                        totalAmount -= stock.Amount;
                        item.Deliveries.Add(
                            new Delivery()
                            {
                                Amount = stock.Amount,
                                ProductId = entry.ProductId,
                                DeliveryBillId = item.Id,
                                Note = entry.Note,
                                Price = stock.Price,
                                StorageId = stock.StorageId
                            });
                        this._stockRepository.Delete(stock);
                    }
                }
                if (totalAmount > 0)
                {
                    throw new UserFriendlyException($"商品[{entry.Name}]出库数量大于库存量,出库失败");
                }
            }

            item.Code = this.GetMaxCode();
            await this._deliveryBillRepository.InsertAsync(item);
            this.CurrentUnitOfWork.SaveChanges();
            return this._deliveryRepository.GetAllIncluding(r => r.Product, r => r.Storage).Where(r => r.DeliveryBillId == item.Id).ToList().MapTo<List<ProductStockListDto>>();
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this._deliveryBillRepository.Get(r => r.Code.StartsWith("CK" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"CK{preCode}001";
            }
            else
            {
                return $"CK{(long.Parse(maxCode.Substring(2)) + 1):000}";
            }
        }
    }
}



