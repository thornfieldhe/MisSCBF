// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;

    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 出库服务
    /// </summary>
    [AbpAuthorize]
    public class DeliveryAppService : TAFAppServiceBase, IDeliveryAppService
    {
        private readonly IProductRepository productRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IDeliveryRepository deliveryRepository;

        public DeliveryAppService(IProductRepository productRepository,
                                  IDeliveryRepository deliveryRepository,
                                  ISysDictionaryRepository sysDictionaryRepository)
        {
            this.productRepository = productRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.deliveryRepository = deliveryRepository;
        }

        /// <summary>
        /// 出库
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



