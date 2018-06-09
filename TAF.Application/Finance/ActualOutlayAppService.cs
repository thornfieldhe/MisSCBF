// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlayAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Dynamic;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using SCBF.BaseInfo;
    using SCBF.Finance.Dto;
    using TAF.Utility;

    /// <summary>
    /// 实际支出服务
    /// </summary>
    [AbpAuthorize]
    public class ActualOutlayAppService : TAFAppServiceBase, IActualOutlayAppService
    {
        private readonly IActualOutlayRepository _actualOutlayRepository;
        private readonly IRelationshipRepository _relationshipRepository;
        private readonly ISysDictionaryRepository _sysDictionaryRepository;
        private IWorkbook _workbook = null;

        public ActualOutlayAppService(
            IActualOutlayRepository actualOutlayRepository,
            IRelationshipRepository relationshipRepository,
            ISysDictionaryRepository sysDictionaryRepository)
        {
            this._actualOutlayRepository = actualOutlayRepository;
            this._relationshipRepository = relationshipRepository;
            this._sysDictionaryRepository = sysDictionaryRepository;
        }


        public List<ActualOutlayListDto> Get()
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var result =
                this._actualOutlayRepository.GetAllList(r => r.Year == year && !r.OutlayId.HasValue).OrderBy(r => r.VoucherNo).ToList().MapTo<List<ActualOutlayListDto>>();
            return result;
        }

        public List<ActualOutlayListDto> GetByOutlayId(Guid outlayId)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);
            var result =
                this._actualOutlayRepository.GetAllList(r => r.Year == year && r.OutlayId == outlayId).OrderBy(r => r.VoucherNo).ToList().MapTo<List<ActualOutlayListDto>>();
            return result;
        }

        public Guid LoadActualOutlayFile(string path, object param)
        {
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var modelId = Guid.NewGuid();
            if (path.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0)// 2007版本
            {
                this._workbook = new XSSFWorkbook(fs);
            }
            else if (path.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0)// 2003版本
            {
                this._workbook = new HSSFWorkbook(fs);
            }
            else
            {
                throw new UserFriendlyException("上传文件格式不正确");
            }


            var currentYear = this._sysDictionaryRepository.FirstOrDefault(r => r.Category == DictionaryCategory.Budget_Year && r.Value4 == true.ToString());
            if (currentYear == null)
            {
                throw new UserFriendlyException("未设置预算年度");
            }

            var list = new List<ActualOutlay>();
            var sheet = this._workbook.GetSheetAt(0);
            //最后一列的标号
            var rowCount = sheet.LastRowNum + 1;

            for (var i = 2; i < rowCount; i++)
            {
                var row = sheet.GetRow(i);
                if (row.GetCell(1) != null && !string.IsNullOrEmpty(row.GetCell(1).ToString()))
                {
                    var item = new ActualOutlay()
                    {
                        Amount = row.GetCell(2).ToStr().ToDecimal(),
                        Date = row.GetCell(1).ToStr().ToDate(),
                        Note = row.GetCell(3).ToStr(),
                        VoucherNo = row.GetCell(0).ToStr(),
                        FileId = modelId,
                        Year = currentYear.Value.ToInt()
                    };
                    list.Add(item);
                }
            }
            var lastItem =
                this._actualOutlayRepository.Get(r => r.Year.ToString() == currentYear.Value)
                    .OrderByDescending(r => r.VoucherNo).FirstOrDefault(); //最后一笔凭证
            if (lastItem != null)
            {
                list.RemoveAll(r => string.CompareOrdinal(r.VoucherNo, lastItem.VoucherNo) <= 0);
            }
            this._actualOutlayRepository.InsertRange(list);
            return modelId;
        }


        public void Update(OutlayEditDto input)
        {
            foreach (var value in input.OutlayIds)
            {
                var item = this._actualOutlayRepository.FirstOrDefault(r => r.Id == value);
                if (item == null)
                {
                    throw new UserFriendlyException($"该支出项目不存在:{value}");
                }

                item.OutlayId = input.Id;
                this._actualOutlayRepository.Update(item);
            }
        }

        public ListResultDto<ActualOutlayListDto> LoadUnLinkOutlays(ActualAuditQueryDto request)
        {
            var currentYearItem = this._sysDictionaryRepository.FirstOrDefault(r => r.Value4 == true.ToString() && r.Category == DictionaryCategory.Budget_Year);
            if (currentYearItem == null)
            {
                throw new UserFriendlyException("预算年度不存在");
            }
            var year = int.Parse(currentYearItem.Value);

            var rIds = (from r in this._relationshipRepository.GetAll()
                where r.Type == request.Type
                select r.ForeignKey).ToList();

            var result = (from a in this._actualOutlayRepository.GetAll()
                where !rIds.Contains(a.Id) && a.Year == year &&
                      (string.IsNullOrEmpty(request.Text)|| a.VoucherNo.Contains(request.Text)||a.Note.Contains(request.Text))
                select a).OrderByDescending(r=>r.VoucherNo);
            var count = result.Count();
            var list = result.AsQueryable().PageBy(request).ToList().MapTo<List<ActualOutlayListDto>>();
            return new PagedResultDto<ActualOutlayListDto>(count, list);
        }

        public ListResultDto<ActualOutlayListDto> LoadLinkedOutlays(ActualAuditQueryDto request)
        {
            if (!request.PrincipalKey.HasValue)
            {
                throw new UserFriendlyException("请输入凭证关联对象");
            }

            var result = (from a in this._actualOutlayRepository.GetAll()
                join
                    r in this._relationshipRepository.GetAll() on a.Id equals r.ForeignKey
                where r.PrincipalKey == request.PrincipalKey.Value &&
                      (string.IsNullOrEmpty(request.Text) || a.VoucherNo.Contains(request.Text) ||a.Note.Contains(request.Text))
                select a).OrderByDescending(r => r.VoucherNo);
            var count = result.Count();
            var list  = result.AsQueryable().PageBy(request).ToList().MapTo<List<ActualOutlayListDto>>();
            return new PagedResultDto<ActualOutlayListDto>(count, list);
        }
    }
}



