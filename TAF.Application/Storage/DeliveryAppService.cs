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
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using SCBF.Storage.Dto;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 出库服务
    /// </summary>
    [AbpAuthorize]
    public class DeliveryAppService : TAFAppServiceBase, IDeliveryAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryAppService(IProductRepository productRepository,
                                  IDeliveryRepository deliveryRepository,
                                  ISysDictionaryRepository sysDictionaryRepository)
        {
            this._productRepository = productRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
            this._deliveryRepository = deliveryRepository;
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductStockListDto Entry(ProductStockQueryDto request)
        {
            var product = this._productRepository.FirstOrDefault(r => r.Code == request.Code);
            if (product == null)
            {
                throw new UserFriendlyException("当前商品不存在");
            }
            var output = product.MapTo<ProductStockListDto>();
            output.StorageName = this._sysDictionaryRepository.Get(request.StorageId).Value;

            output.StorageId = request.StorageId;
            output.Amount = 1;
            return output;
        }

        public List<ProductStockListDto> Get(Guid billId)
        {
            var list = this._deliveryRepository.GetAllList(r => r.DeliveryBillId == billId);
            return list.MapTo<List<ProductStockListDto>>();
        }
    }
}



