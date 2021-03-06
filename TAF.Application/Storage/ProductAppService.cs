﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品服务
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
    using Abp.UI;

    using AutoMapper;

    using SCBF.Storage.Dto;
    using TAF.Utility;

    /// <summary>
    /// 商品服务
    /// </summary>
    [AbpAuthorize]
    public class ProductAppService : TAFAppServiceBase, IProductAppService
    {
        private readonly IProductRepository productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ListResultDto<ProductListDto> GetAll(ProductQueryDto request)
        {
            var query = this.productRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name) || r.PYCode.Contains(request.Name.ToUpper()))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Unit), r => r.Unit == request.Unit)
                .WhereIf(request.CategoryId != Guid.Empty, r => r.CategoryId == request.CategoryId);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ProductListDto>>();

            return new PagedResultDto<ProductListDto>(count, dtos);
        }

        public ProductEditDto Get(Guid id)
        {
            var output = this.productRepository.Get(id);
            return output.MapTo<ProductEditDto>();
        }

        public async Task SaveAsync(ProductEditDto input)
        {
            var item = input.MapTo<Product>();
            item.PYCode = item.Name.GetChineseSpell();
            if (input.Id == Guid.Empty)
            {
                if (this.productRepository.Count(r => r.Code == input.Code) > 0)
                {
                    throw new UserFriendlyException("当前商品已存在");
                }
                await this.productRepository.InsertAsync(item);
            }
            else
            {
                var old = this.productRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.productRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.productRepository.Delete(id);
        }
    }
}



