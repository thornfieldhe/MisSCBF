// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点服务
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
    /// 盘点服务
    /// </summary>
    [AbpAuthorize]
    public class CheckAppService : TAFAppServiceBase, ICheckAppService
    {
        private readonly ICheckRepository checkRepository;

        public CheckAppService(ICheckRepository checkRepository)
        {
            this.checkRepository = checkRepository;
        }

        public ListResultDto<CheckListDto> GetAll(CheckQueryDto request)
        {
            var query = this.checkRepository.GetAll()
            
                .WhereIf(request.ProductId.HasValue, r => r.ProductId == request.ProductId.Value)             
                .WhereIf(request.StockAmount.HasValue, r => r.StockAmount == request.StockAmount.Value)             
                .WhereIf(request.Amount.HasValue, r => r.Amount == request.Amount.Value)             
                .WhereIf(request.ChangedAmount.HasValue, r => r.ChangedAmount == request.ChangedAmount.Value)             
                .WhereIf(!string.IsNullOrWhiteSpace(request.Reason), r => r.Reason.Contains(request.Reason))            
                .WhereIf(request.Price.HasValue, r => r.Price == request.Price.Value)             
                .WhereIf(request.StorageId.HasValue, r => r.StorageId == request.StorageId.Value) ; 

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Product.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<CheckListDto>>();

            return new PagedResultDto<CheckListDto>(count, dtos);
        }

        public CheckEditDto Get(Guid id)
        {
            var output = this.checkRepository.Get(id);
            return output.MapTo<CheckEditDto>();
        }

        public async Task SaveAsync(CheckEditDto input)
        {
            var item = input.MapTo<Check>();
            if (input.Id == Guid.Empty)
            {
                await this.checkRepository.InsertAsync(item);
            }
            else
            {
                var old = this.checkRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.checkRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.checkRepository.Delete(id);
        }
    }
}



