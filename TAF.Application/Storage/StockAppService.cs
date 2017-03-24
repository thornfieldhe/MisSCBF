// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using AutoMapper;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 库存服务
    /// </summary>
    [AbpAuthorize]
    public class StockAppService : TAFAppServiceBase, IStockAppService
    {
        private readonly IStockRepository stockRepository;

        public StockAppService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public ListResultDto<StockListDto> GetAll(StockQueryDto request)
        {
            var query = this.stockRepository.GetAll()
            
                .WhereIf(request.ProductId.HasValue, r => r.ProductId == request.ProductId.Value)             
                .WhereIf(request.Amount.HasValue, r => r.Amount == request.Amount.Value)             
                .WhereIf(request.StorageId.HasValue, r => r.StorageId == request.StorageId.Value) ; 

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<StockListDto>>();

            return new PagedResultDto<StockListDto>(count, dtos);
        }

        public StockEditDto Get(Guid id)
        {
            var output = this.stockRepository.Get(id);
            return output.MapTo<StockEditDto>();
        }

        public async Task SaveAsync(StockEditDto input)
        {
            var item = input.MapTo<Stock>();
            if (input.Id == Guid.Empty)
            {
                await this.stockRepository.InsertAsync(item);
            }
            else
            {
                var old = this.stockRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.stockRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.stockRepository.Delete(id);
        }
    }
}



