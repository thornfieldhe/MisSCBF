// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using Abp.UI;
using SCBF.BaseInfo;
using SCBF.Common;
using TAF.Utility;

namespace SCBF.Purchase
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
    using SCBF.Purchase.Dto;

    /// <summary>
    /// 投标过程管理服务
    /// </summary>
    [AbpAuthorize]
    public class ProcessManagementAppService : TAFAppServiceBase, IProcessManagementAppService
    {
        private readonly IProcessManagementRepository _processManagementRepository;
        private readonly ISysDictionaryRepository     _sysDictionaryRepository;
        private readonly IProcurementPlanRepository   _procurementPlanRepository;
        private readonly IActualOutlayRepository      _actualOutlayRepository;
        private readonly IRelationshipRepository      _relationshipRepository;

        public ProcessManagementAppService(IProcessManagementRepository processManagementRepository,
            ISysDictionaryRepository                                    sysDictionaryRepository,
            IProcurementPlanRepository                                  procurementPlanRepository,
            IActualOutlayRepository                                     actualOutlayRepository,
            IRelationshipRepository                                     relationshipRepository)
        {
            this._processManagementRepository = processManagementRepository;
            this._sysDictionaryRepository     = sysDictionaryRepository;
            this._procurementPlanRepository   = procurementPlanRepository;
            this._actualOutlayRepository      = actualOutlayRepository;
            this._relationshipRepository      = relationshipRepository;
        }

        public ListResultDto<ProcessManagementListDto> GetAll(ProcessManagementQueryDto request)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            var query = this._processManagementRepository.GetAll()
                .Where(r => r.Type == request.Type && r.Year == year)
                .WhereIf(request.ProcurementPlanId.HasValue,
                    r => r.PurchaseId == request.ProcurementPlanId.Value)
                .WhereIf(request.Unit.HasValue, r => r.Unit == request.Unit.Value)
                .OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list  = query.AsQueryable().PageBy(request).ToList();
            var dtos  = list.MapTo<List<ProcessManagementListDto>>();

            foreach (var dto in dtos)
            {
                var unit = this._sysDictionaryRepository.FirstOrDefault(r => r.Category == request.Type && r.Id==dto.Unit);
                if (unit == null)
                {
                    throw new UserFriendlyException("未找到单位");
                }

                var users = (from r in this._relationshipRepository.GetAll()
                    join p in this._processManagementRepository.GetAll() on r.PrincipalKey equals p.Id
                    join u in this._sysDictionaryRepository.GetAll() on r.ForeignKey equals u.Id
                    where p.Id == dto.Id
                    select u.Value).ToList();
                dto.Users = string.Join(",", users);

                dto.UnitName     = unit.Value;
                dto.PurchaseName = this._procurementPlanRepository.FirstOrDefault(r => r.Id == dto.PurchaseId)?.Name;
                dto.Schedule = dto.Price * 0.8M - (from r in this._relationshipRepository.GetAll()
                                   join c in this._actualOutlayRepository.GetAll() on r.ForeignKey equals c.Id
                                   where r.PrincipalKey == dto.Id
                                   select c.Amount).ToList().Sum();
            }

            return new PagedResultDto<ProcessManagementListDto>(count, dtos);
        }

        public ProcessManagementEditDto Get(Guid id)
        {
            var output = this._processManagementRepository.Get(id);
            var result = output.MapTo<ProcessManagementEditDto>();
            result.Users = this._relationshipRepository.GetAllList(r => r.PrincipalKey == id).Select(r => r.ForeignKey)
                .ToList();
            result.UnitName = this._sysDictionaryRepository.Single(r => r.Id == result.Unit).Value;
            result.Schedule = result.Price * 0.8M - (from r in this._relationshipRepository.GetAll()
                                  join c in this._actualOutlayRepository.GetAll() on r.ForeignKey equals c.Id
                                  where r.PrincipalKey == result.Id
                                  select c.Amount).ToList().Sum();
            return result;
        }

        public async Task<Guid> SaveAsync(ProcessManagementEditDto input)
        {
            try
            {
                if (this._processManagementRepository.Any(r =>
                    r.PurchaseId == input.PurchaseId && r.Type == input.Type &&
                    (input.Id != r.Id || !input.Id.HasValue)))
                {
                    throw new UserFriendlyException("不能重复添加采购计划");
                }

                var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                    r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
                if (currentYearItem == null)
                {
                    throw new UserFriendlyException("预算年度不存在");
                }

                var year = int.Parse(currentYearItem.Value);

                var item = input.MapTo<ProcessManagement>();
                item.Year = year;
                if (!input.Id.HasValue)
                {
                    item = await this._processManagementRepository.InsertAsync(item);
                }
                else
                {
                    var old = this._processManagementRepository.Get(input.Id.Value);
                    if (old.Status == ProcessStatus.Created)
                    {
                        return old.Id;
                    }

                    item = Mapper.Map(input, old);
                    await this._processManagementRepository.UpdateAsync(old);
                    await this._relationshipRepository.DeleteAsync(r => r.PrincipalKey == input.Id.Value);
                }


                this._relationshipRepository.InsertRange(input.Users.Select(r =>
                    new Relationship() {PrincipalKey = item.Id, ForeignKey = r, Type = input.Type}));
                return item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通用的上传附件方法
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Guid UploadAttachment(string path, object id)
        {
            return new Guid((id as string[])[1]);
        }

        public string Print(Guid id)
        {
            var old = this._processManagementRepository.Get(id);
            old.Status = ProcessStatus.NoticePrinted;
            this._processManagementRepository.Update(old);

            return DownloadFileService.Load("LetterOfAcceptance.doc", "中标通知书.doc", new string[] { })
                .ExcuteDoc(old, this.ExportToDoc);
        }

        public ProcessManagementEditDto SavePrice(KeyValue<Guid, decimal> price)
        {
            this._processManagementRepository.Update(price.Key, r =>
            {
                r.Price  = price.Value;
                r.Status = ProcessStatus.AmountDetermined;
            });
            return this.Get(price.Key);
        }

        public List<KeyValue<Guid, string>> GetPurchases()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r =>
                r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }

            var year = int.Parse(currentYearItem.Value);
            return this._procurementPlanRepository.GetAllList(r=>r.Year==year)
                .Select(r => new KeyValue<Guid, string>() {Key = r.Id, Value = r.Name}).ToList();
        }


        public void Delete(Guid id)
        {
            this._processManagementRepository.Delete(id);
            this._relationshipRepository.Delete(r => r.ForeignKey == id);
        }

        private KeyValue<DataSet, string[], object[]> ExportToDoc(object l)
        {
            ProcessManagement input = l as ProcessManagement;
            var               unit  = this._sysDictionaryRepository.FirstOrDefault(r => r.Id == input.Unit).Value;
            var project =
                this._procurementPlanRepository.FirstOrDefault(r => r.Id == input.PurchaseId).Name;
            var date = $"{DateTime.Now.Year}年{DateTime.Today.Month}月{DateTime.Now.Day}日";
            return new KeyValue<DataSet, string[], object[]>(new DataSet(), new[] {"Unit", "Project", "Date"},
                new[] {unit, project, date});
        }
    }
}
