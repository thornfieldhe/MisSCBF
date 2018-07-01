// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using SCBF.BaseInfo;
using SCBF.Common;
using TAF.Utility;

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 会质量评价体系服务
    /// </summary>
    [AbpAuthorize]
    public class BlacklistAppService : TAFAppServiceBase, IBlacklistAppService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;

        public BlacklistAppService(IBlacklistRepository blacklistRepository,
            ISysDictionaryRepository sysDictionaryRepository)
        {
            this._blacklistRepository = blacklistRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }

        public ListResultDto<BlacklistListDto> GetAll(BlacklistQueryDto request)
        {
            var query = this._blacklistRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(request.Type), r => r.Type.Contains(request.Type)).ToList();
            var dtos = query.MapTo<List<BlacklistListDto>>();
            foreach (var item in dtos)
            {
                if (item.Type != DictionaryCategory.Purchase_Supplier)
                {
                    var id = new Guid(item.Name);
                    item.Name = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == id).Value;
                }

                switch (item.Type)
                {
                     case    DictionaryCategory.Purchase_DesignUnit:
                         item.Type = "设计单位";
                         break;
                     case    DictionaryCategory.Purchase_CostUnit:
                         item.Type = "造价单位";
                         break;
                     case    DictionaryCategory.Purchase_ConstructionControlUnit:
                         item.Type = "监理单位";
                         break;
                     case    DictionaryCategory.Purchase_BiddingAgency:
                         item.Type = "招标代理单位";
                         break;
                     case    DictionaryCategory.Purchase_Supplier:
                         item.Type = "供应商管";
                         break;
                }
            }

            dtos = dtos.Where(r => r.Name.Contains(request.Name)).ToList();
            var count = dtos.Count;
            var list = dtos.AsQueryable().PageBy(request).ToList();

            return new PagedResultDto<BlacklistListDto>(count, list);
        }

        public void Delete(Guid id)
        {
            this._blacklistRepository.Delete(id);
        }

        public string ExportDoc()
        {
            return DownloadFileService.Load("黑名单函模板.doc", "黑名单函.doc", new string[] { })
                .ExcuteDoc(null, this.ExportToDoc);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc(object arg)
        {
            var query = this._blacklistRepository.GetAllList();
            var dtos = query.MapTo<List<BlacklistListDto>>();
            foreach (var item in dtos)
            {
                if (item.Type != DictionaryCategory.Purchase_Supplier)
                {
                    var id = new Guid(item.Name);
                    item.Name = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == id).Value;
                }
            }

            var value = new[]
            {
                "供应商",
                "招标代理机构",
                "设计单位",
                "咨询单位",
                "监理单位",
                "日期"
            };

            var item3 = new[]
            {
                string.Join(",", dtos.Where(r => r.Type == DictionaryCategory.Purchase_Supplier).Select(r => r.Name)),
                string.Join(",",
                    dtos.Where(r => r.Type == DictionaryCategory.Purchase_BiddingAgency).Select(r => r.Name)),
                string.Join(",", dtos.Where(r => r.Type == DictionaryCategory.Purchase_DesignUnit).Select(r => r.Name)),
                string.Join(",", dtos.Where(r => r.Type == DictionaryCategory.Purchase_CostUnit).Select(r => r.Name)),
                string.Join(",",
                    dtos.Where(r => r.Type == DictionaryCategory.Purchase_ConstructionControlUnit).Select(r => r.Name)),
                DateTime.Now.ToString("yyyy年M月d日")
            };


            var ds = new DataSet();
            var dt = new DataTable();
            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }

        /// <summary>
        /// 从黑名单中移除单位
        /// </summary>
        public void RemoveFromList()
        {
            var limitYear = int.Parse(this._sysDictionaryRepository
                .FirstOrDefault(r => r.Category == DictionaryCategory.Purchase_BlackList).Value);
            var limitDate = DateTime.Now.AddYears(-limitYear);
            this._blacklistRepository.Delete(r => r.CreationTime >= limitDate);
        }
    }
}



