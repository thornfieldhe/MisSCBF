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
        private readonly IProductRepository productRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public EntryAppService(IProductRepository productRepository, ISysDictionaryRepository sysDictionaryRepository)
        {
            this.productRepository = productRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductStockListDto Entry(ProductStockQueryDto request)
        {
            var product = this.productRepository.FirstOrDefault(r => r.Code == request.Code);
            if (product == null)
            {
                throw new UserFriendlyException("当前商品不存在");
            }
            var output = product.MapTo<ProductStockListDto>();

            output.StorageName = this.sysDictionaryRepository.Get(request.StorageId).Value;
            output.StorageId = request.StorageId;
            output.Amount = 1;
            return output;
        }
    }
}



