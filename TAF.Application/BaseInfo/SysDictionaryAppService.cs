﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置服务
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

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 系统配置服务
    /// </summary>
    [AbpAuthorize]
    public class SysDictionaryAppService : TAFAppServiceBase, ISysDictionaryAppService
    {
        private readonly ISysDictionaryRepository sysDictionaryRepository;

        public SysDictionaryAppService(ISysDictionaryRepository sysDictionaryRepository)
        {
            this.sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<SysDictionaryListDto> GetAll(SysDictionaryQueryDto request)
        {
            var query =
                this.sysDictionaryRepository.GetAll()
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Category), r => r.Category.Contains(request.Category))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Value), r => r.Value.Contains(request.Value))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Value2), r => r.Value2.Contains(request.Value2))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Value3), r => r.Value3.Contains(request.Value3))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Value4), r => r.Value4.Contains(request.Value4))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Value5), r => r.Value5.Contains(request.Value5))
                    .WhereIf(!string.IsNullOrWhiteSpace(request.Note), r => r.Note.Contains(request.Note));

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.Value);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<SysDictionaryListDto>>();

            return new PagedResultDto<SysDictionaryListDto>(count, dtos);
        }

        public SysDictionaryEditDto Get(Guid id)
        {
            var output = this.sysDictionaryRepository.Get(id);
            return output.MapTo<SysDictionaryEditDto>();
        }

        public async Task SaveAsync(SysDictionaryEditDto input)
        {
            var item = input.MapTo<SysDictionary>();
            if (input.Id == Guid.Empty)
            {
                await this.sysDictionaryRepository.InsertAsync(item);
            }
            else
            {
                var old = this.sysDictionaryRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.sysDictionaryRepository.UpdateAsync(old);
            }
        }

        /// <summary>
        /// 保存预算年度
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task SaveYearAsync(SysDictionaryEditDto input)
        {
            var item = input.MapTo<SysDictionary>();
            var dbItem =
                this.sysDictionaryRepository.FirstOrDefault(
                    r => r.Category == input.Category && r.Value == input.Value);//存在预算年度
            if (dbItem==null)
            {
                var defaultYear =
                    this.sysDictionaryRepository.FirstOrDefault(
                        r => r.Category == input.Category && r.Value4 == true.ToString());//item4:是否是当前年度
                if(defaultYear!=null)
                {
                    defaultYear.Value4 = false.ToString();
                }
                item.Value4 = true.ToString();
                await this.sysDictionaryRepository.InsertAsync(item);
            }
            else
            {
                throw new UserFriendlyException("该预算年度已存在");
            }
        }

        public void Delete(Guid id)
        {
            this.sysDictionaryRepository.Delete(id);
        }

        public List<SysDictionaryListDto> GetSimpleList(string category=null)
        {
            return this.sysDictionaryRepository.GetAllList(r=> category==null || r.Category==category).MapTo<List<SysDictionaryListDto>>();
        }

        public string GetModulePath(string category) { return $"{category}/{DateTime.Today.Year}/{DateTime.Today.Month}/{DateTime.Today.Day}"; }
    }
}



