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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 入库服务
    /// </summary>
    [AbpAuthorize]
    public class EntryAppService : TAFAppServiceBase, IEntryAppService
    {
        private readonly IEntryRepository entryRepository;
        private readonly IProductRepository productRepository;

        public EntryAppService(IEntryRepository entryRepository, IProductRepository productRepository)
        {
            this.entryRepository = entryRepository;
            this.productRepository = productRepository;
        }

        public ListResultDto<EntryListDto> GetAll(EntryQueryDto request)
        {
            var query = from e in this.entryRepository.GetAll()
                        join p in this.productRepository.GetAll() on e.ProductId equals p.Id
                        where
                        (//e.IsSpecial == request.IsSpecial
                         //                         && ((request.Code != null && e.Code.Contains(request.Code)) || request.Code == null)
                         //                         && ((request.StorageId.HasValue && e.StorageId == request.StorageId)
                         //                             || !request.StorageId.HasValue)
                         true && ((request.Product != null && (p.Name.Contains(request.Product) || p.Code == request.Product))
                             || request.Product == null)
                        && ((request.DateFrom.HasValue && p.CreationTime >= request.DateFrom.Value)
                            || !request.DateFrom.HasValue)
                        && ((request.DateTo.HasValue && p.CreationTime <= request.DateTo.Value.AddDays(1))
                            || !request.DateTo.HasValue))
                        select
                        new EntryListDto
                        {
                            //                            Code = e.Code,
                            Id = e.Id,
                            Amount = e.Amount,
                            Note = e.Note,
                            ProductName = p.Name,
                            StorageName = "",
                            Unit = p.Unit
                        };


            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Code);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<EntryListDto>>();

            return new PagedResultDto<EntryListDto>(count, dtos);
        }

        public ListResultDto<EntryListDto> SaveAll(List<EntryEditDto> list)
        {
            throw new NotImplementedException();
        }
    }
}



