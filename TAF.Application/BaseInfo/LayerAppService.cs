// --------------------------------------------------------------------------------------------------------------------
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

    using AutoMapper;

    using SCBF.BaseInfo.Dto;

    using TAF.Utility;

    /// <summary>
    /// 商品类别服务
    /// </summary>
    [AbpAuthorize]
    internal class LayerAppService : TAFAppServiceBase, ILayerAppService
    {
        private readonly ILayerRepository layerRepository;

        public LayerAppService(ILayerRepository layerRepository)
        {
            this.layerRepository = layerRepository;
        }

        public ListResultDto<LayerListDto> GetAll(LayerQueryDto request)
        {
            var query = this.layerRepository.GetAll()

                .WhereIf(request.PId.HasValue, r => r.PId == request.PId.Value)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name));

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
                    item.PName = item.PId.HasValue ? this.layerRepository.Get(item.PId.Value).Name : string.Empty;
                });
            return new PagedResultDto<LayerListDto>(count, dtos);
        }

        public LayerEditDto Get(Guid id)
        {
            var output = this.layerRepository.Get(id);
            return output.MapTo<LayerEditDto>();
        }

        public async Task SaveAsync(LayerEditDto input)
        {
            var item = input.MapTo<Layer>();
            var maxLevelCode = GetMaxLevelCode(input);
            if (input.Id == Guid.Empty)
            {
                item.LevelCode = maxLevelCode;
                item.Level = maxLevelCode.Length / 2;
                await this.layerRepository.InsertAsync(item);
            }
            else
            {
                var old = this.layerRepository.Get(input.Id);
                var changed =
                    this.layerRepository.GetAllList(r => r.LevelCode.StartsWith(old.LevelCode) && r.Level != old.Level);
                changed.ForEach(
                    r =>
                        {
                            r.LevelCode = maxLevelCode + r.LevelCode.Substring(old.LevelCode.Length, r.LevelCode.Length - old.LevelCode.Length);
                            r.Level = r.LevelCode.Length / 2;
                        });
                old.LevelCode = maxLevelCode;
                old.Level = old.LevelCode.Length / 2;

                Mapper.Map(input, old);
                await this.layerRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.layerRepository.Delete(id);
        }

        public List<LayerListDto> GetAll(string category)
        {
            var list = this.layerRepository.GetAllList(r => r.Category == category).MapTo<List<LayerListDto>>();
            Parallel.ForEach(
                list,
                item =>
                    {
                        item.PName = item.PId.HasValue ? this.layerRepository.Get(item.PId.Value).Name : string.Empty;
                    });
            return list;
        }

        /// <summary>
        /// 获取当前最新层级
        /// </summary>
        /// <returns></returns>
        private string GetMaxLevelCode(LayerEditDto input)
        {
            var maxItem = layerRepository.GetAll().OrderByDescending(r => r.LevelCode).FirstOrDefault(r => r.PId == input.PId);

            //当前层级没有项目
            if (maxItem == null)
            {
                var parent = layerRepository.FirstOrDefault(r => r.Id == input.PId);

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



