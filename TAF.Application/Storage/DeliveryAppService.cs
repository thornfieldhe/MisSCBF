//// --------------------------------------------------------------------------------------------------------------------
//// <copyright file="DeliveryAppService.cs" company="" author="何翔华">
////   
//// </copyright>
//// <summary>
////   出库服务
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------
//
//namespace SCBF.Storage
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Dynamic;
//    using System.Threading.Tasks;
//
//    using Abp.Application.Services.Dto;
//    using Abp.Authorization;
//    using Abp.AutoMapper;
//    using Abp.Linq.Extensions;
//
//    using AutoMapper;
//
//    using SCBF.Storage.Dto;
//
//    /// <summary>
//    /// 出库服务
//    /// </summary>
//    [AbpAuthorize]
//    public class DeliveryAppService : TAFAppServiceBase, IDeliveryAppService
//    {
//        private readonly IDeliveryRepository deliveryRepository;
//
//        public DeliveryAppService(IDeliveryRepository deliveryRepository)
//        {
//            this.deliveryRepository = deliveryRepository;
//        }
//
//        public ListResultDto<DeliveryListDto> GetAll(DeliveryQueryDto request)
//        {
//            var query = this.deliveryRepository.GetAll()
//            
//                .WhereIf(request.ProductId.HasValue, r => r.ProductId == request.ProductId.Value)             
//                .WhereIf(!string.IsNullOrWhiteSpace(request.Unit), r => r.Unit.Contains(request.Unit))            
//                .WhereIf(request.Amount.HasValue, r => r.Amount == request.Amount.Value)             
//                .WhereIf(request.DeliveryBillId.HasValue, r => r.DeliveryBillId == request.DeliveryBillId.Value)             
//                .WhereIf(!string.IsNullOrWhiteSpace(request.Note), r => r.Note.Contains(request.Note))            
//                .WhereIf(request.StorageId.HasValue, r => r.StorageId == request.StorageId.Value) ; 
//
//            query = !string.IsNullOrWhiteSpace(request.Sorting)
//                        ? query.OrderBy(request.Sorting)
//                        : query.OrderBy(r => r.Name);
//            var count = query.Count();
//            var list = query.AsQueryable().PageBy(request).ToList();
//            var dtos = list.MapTo<List<DeliveryListDto>>();
//
//            return new PagedResultDto<DeliveryListDto>(count, dtos);
//        }
//
//        public DeliveryEditDto Get(Guid id)
//        {
//            var output = this.deliveryRepository.Get(id);
//            return output.MapTo<DeliveryEditDto>();
//        }
//
//        public async Task SaveAsync(DeliveryEditDto input)
//        {
//            var item = input.MapTo<Delivery>();
//            if (input.Id == Guid.Empty)
//            {
//                await this.deliveryRepository.InsertAsync(item);
//            }
//            else
//            {
//                var old = this.deliveryRepository.Get(input.Id);
//                Mapper.Map(input, old);
//                await this.deliveryRepository.UpdateAsync(old);
//            }
//        }
//
//        public void Delete(Guid id)
//        {
//            this.deliveryRepository.Delete(id);
//        }
//    }
//}
//
//
//
