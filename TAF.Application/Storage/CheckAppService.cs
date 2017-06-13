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
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;
    using AutoMapper;
    using SCBF.Storage.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

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
                .WhereIf(!string.IsNullOrWhiteSpace(request.Code), r => r.CheckBill.Code.Contains(request.Code))
                .WhereIf(!string.IsNullOrWhiteSpace(request.ProductCode), r => r.Product.Code.Contains(request.ProductCode))
                .WhereIf(!string.IsNullOrWhiteSpace(request.ProductName), r => r.Product.Name.Contains(request.ProductName))
            .WhereIf(request.BillId.HasValue, r => r.CheckBillId == request.BillId.Value);
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



