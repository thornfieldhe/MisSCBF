// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 入库服务
    /// </summary>
    [AbpAuthorize]
    public class EntryAppService : TAFAppServiceBase, IEntryAppService
    {
        private readonly IEntryRepository entryRepository;
        private readonly IProductRepository productRepository;
        private readonly IStockRepository stockRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public EntryAppService(IEntryRepository entryRepository
            , IProductRepository productRepository
            , IStockRepository stockRepository
            , ISysDictionaryRepository sysDictionaryRepository)
        {
            this.entryRepository = entryRepository;
            this.productRepository = productRepository;
            this.stockRepository = stockRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductInStockListDto Entry(ProductStockQueryDto request)
        {
            ProductInStockListDto output;
            var stock =
                this.stockRepository.FirstOrDefault(
                    r => r.Product.Code == request.Code && r.StorageId == request.StorageId);
            if (stock == null)
            {
                var product = this.productRepository.Get(r => r.Code == request.Code);
                if (product == null)
                {
                    throw new UserFriendlyException("当前商品不存在");
                }
                output = product.MapTo<ProductInStockListDto>();
                output.Amount = 1;
                output.StockBalance = 0;
                output.StorageName = this.sysDictionaryRepository.Get(request.StorageId).Value;
            }
            else
            {
                output = stock.MapTo<ProductInStockListDto>();
            }
            return output;
        }

        //        public ListResultDto<ProductInStockListDto> GetAll(EntryQueryDto request)
        //        {
        //            var query = from e in this.entryRepository.GetAll()
        //                        join p in this.productRepository.GetAll() on e.ProductId equals p.Id
        //                        where
        //                        (e.EntryBill.IsSpecial == request.IsSpecial
        //                                                  && ((request.Code != null && e.EntryBill.Code.Contains(request.Code)) || request.Code == null)
        //                                                  && ((request.StorageId.HasValue && e.EntryBill.StorageId == request.StorageId) || !request.StorageId.HasValue)
        //                          && ((request.Product != null && (e.Product.Name.Contains(request.Product) || p.Code == request.Product))
        //                             || request.Product == null)
        //                        && ((request.DateFrom.HasValue && p.CreationTime >= request.DateFrom.Value)
        //                            || !request.DateFrom.HasValue)
        //                        && ((request.DateTo.HasValue && p.CreationTime <= request.DateTo.Value.AddDays(1))
        //                            || !request.DateTo.HasValue))
        //                        select
        //                        new ProductInStockListDto
        //                        {
        //                            //                            Code = e.Code,
        //                            Id = e.Id,
        //                            Amount = e.Amount,
        //                            Note = e.Note,
        //                            ProductName = p.Name,
        //                            StorageName = "",
        //                            Unit = p.Unit
        //                        };
        //
        //
        //            query = !string.IsNullOrWhiteSpace(request.Sorting)
        //                        ? query.OrderBy(request.Sorting)
        //                        : query.OrderBy(r => r.Code);
        //            var count = query.Count();
        //            var list = query.AsQueryable().PageBy(request).ToList();
        //            var dtos = list.MapTo<List<ProductInStockListDto>>();
        //
        //            return new PagedResultDto<ProductInStockListDto>(count, dtos);
        //        }


    }
}



