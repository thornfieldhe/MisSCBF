﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
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

    using Dto;

    using TAF.Utility;

    /// <summary>
    /// 商品类别服务
    /// </summary>
    [AbpAuthorize]
    internal class LayerAppService : TAFAppServiceBase, ILayerAppService
    {
        private readonly ILayerRepository _layerRepository;
        private readonly IProductRepository _productRepository;

        public LayerAppService(ILayerRepository layerRepository
            , IProductRepository productRepository)
        {
            this._layerRepository = layerRepository;
            this._productRepository = productRepository;
        }

        public ListResultDto<LayerListDto> GetAll(LayerQueryDto request)
        {
            var query = this._layerRepository.GetAll()

                .WhereIf(request.PId.HasValue, r => r.PId == request.PId.Value)
                .Where(r => r.Category == request.Category);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<LayerListDto>>();
            Parallel.ForEach(
                dtos,
                item =>
                {
                    item.PName = item.PId.HasValue ? this._layerRepository.Get(item.PId.Value).Name : string.Empty;
                });
            return new PagedResultDto<LayerListDto>(count, dtos);
        }

        public List<TreeItemDto> GetAllByCategory(string category)
        {
            
            var list = this._layerRepository.GetAll()
                .Where(r => r.Category == category)
                 .OrderBy(r => r.LevelCode).ToList();
            return list.MapTo<List<TreeItemDto>>();

        }

        public LayerEditDto Get(Guid id)
        {
            var output = this._layerRepository.Get(id);
            return output.MapTo<LayerEditDto>();
        }

        public async Task<Layer> SaveAsync(LayerEditDto input)
        {
            var item = input.MapTo<Layer>();
            var maxLevelCode = this.GetMaxLevelCode(input,input.Category);
            if (input.Id == Guid.Empty)
            {
                item.LevelCode = maxLevelCode;
                item.Level = maxLevelCode.Length / 2;
             return   await this._layerRepository.InsertAsync(item);
            }
            else
            {
                var old = this._layerRepository.Get(input.Id);
                var changed =
                    this._layerRepository.GetAllList(r => r.LevelCode.StartsWith(old.LevelCode) && r.Level != old.Level);
                changed.ForEach(
                    r =>
                        {
                            r.LevelCode = maxLevelCode + r.LevelCode.Substring(old.LevelCode.Length, r.LevelCode.Length - old.LevelCode.Length);
                            r.Level = r.LevelCode.Length / 2;
                        });
                old.LevelCode = maxLevelCode;
                old.Level = old.LevelCode.Length / 2;

                Mapper.Map(input, old);
             return   await this._layerRepository.UpdateAsync(old);
            }
        }

        public async Task SaveAccountAsync(LayerEditDto input)
        {
            var item = input.MapTo<Layer>();
            if (input.Id == Guid.Empty)
            {
                item.Level = item.LevelCode.Length;
                await this._layerRepository.InsertAsync(item);
            }
            else
            {
                var old = this._layerRepository.Get(input.Id);
                var changed =
                    this._layerRepository.GetAllList(r => r.LevelCode.StartsWith(old.LevelCode) && r.Level != old.Level);
                changed.ForEach(
                    r =>
                    {
                        r.Level = r.LevelCode.Length;
                    });

                old.Level = old.LevelCode.Length;

                Mapper.Map(input, old);
                await this._layerRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            var item = this._layerRepository.Get(id);
            if (item == null)
            {
                throw new UserFriendlyException("对象不存在");
            }

            if (this._layerRepository.Count(r => r.Category == item.Category && r.LevelCode.StartsWith(item.LevelCode) && r.Id != item.Id) > 0)
            {
                throw new UserFriendlyException("包含子节点,删除失败");
            }
            this._layerRepository.Delete(id);
        }


        public void DeleteProductCategory(Guid id)
        {
            var item = this._layerRepository.Get(id);
            if (item == null)
            {
                throw new UserFriendlyException("商品分类不存在");
            }

            if (this._layerRepository.Any(r => r.Category == item.Category && r.LevelCode.StartsWith(item.LevelCode) && r.Id != item.Id))
            {
                throw new UserFriendlyException("分类下包含子分类,删除失败");
            }

            if (this._productRepository.Any(r => r.CategoryId == item.Id))
            {
                throw new UserFriendlyException("分类下包含子商品,删除失败");
            }
            this.Delete(id);
        }

        /// <summary>
        /// 获取当前最新层级
        /// </summary>
        /// <returns></returns>
        private string GetMaxLevelCode(LayerEditDto input,string category)
        {
            var maxItem = this._layerRepository.GetAll().Where(r=>r.Category==category).OrderByDescending(r => r.LevelCode).FirstOrDefault(r => r.PId == input.PId);

            //当前层级没有项目
            if (maxItem == null)
            {
                var parent = this._layerRepository.FirstOrDefault(r => r.Id == input.PId);

                //父层级不存在,即为第一条数据;父级存在，即为父级下第一条数据
                return parent == null ? "01" : string.Format("{0}{1}", parent.LevelCode, "01");
            }
            else
            {
                //当前层级最大编号>=9,层级编号直接+1
                if (maxItem.LevelCode.Trim('0').Length % 2 == 0 || maxItem.LevelCode.ToInt() == 9)
                {
                    return (maxItem.LevelCode.ToInt() + 1).ToString();
                }
                return (maxItem.LevelCode.ToInt() + 1).ToString().PadLeft(maxItem.LevelCode.Length, '0');
            }
        }
    }
}



