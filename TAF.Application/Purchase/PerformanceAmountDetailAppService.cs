// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceAmountDetailAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;
using System.Linq;
using SCBF.Common;
using TAF.Utility;

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;

    using AutoMapper;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 履约保证金管理服务
    /// </summary>
    [AbpAuthorize]
    public class PerformanceAmountDetailAppService : TAFAppServiceBase, IPerformanceAmountDetailAppService
    {
        private readonly IPerformanceAmountDetailRepository _performanceAmountDetailRepository;
        private readonly IProcurementPlanRepository _procurementPlanRepository;
        private readonly IPerformanceManageRepository _performanceManageRepository;
        private readonly IBidOpeningManagementRepository _bidOpeningManagementRepository;

        public PerformanceAmountDetailAppService(IPerformanceAmountDetailRepository performanceAmountDetailRepository,
            IProcurementPlanRepository procurementPlanRepository,
            IPerformanceManageRepository performanceManageRepository,
            IBidOpeningManagementRepository bidOpeningManagementRepository)
        {
            this._performanceAmountDetailRepository = performanceAmountDetailRepository;
            this._procurementPlanRepository = procurementPlanRepository;
            this._performanceManageRepository = performanceManageRepository;
            this._bidOpeningManagementRepository = bidOpeningManagementRepository;
        }

        public List<PerformanceAmountDetailDto> GetAll(Guid id)
        {
            var list = this._performanceAmountDetailRepository.GetAllList(r =>
                r.PerformanceManageId == id).MapTo<List<PerformanceAmountDetailDto>>();

            return list;
        }

        public PerformanceAmountDetailDto Get(Guid id)
        {
            var output = this._performanceAmountDetailRepository.Get(id);
            return output.MapTo<PerformanceAmountDetailDto>();
        }

        public async Task SaveAsync(PerformanceAmountDetailDto input)
        {
            var item = input.MapTo<PerformanceAmountDetail>();
            if (!input.Id.HasValue)
            {
                await this._performanceAmountDetailRepository.InsertAsync(item);
            }
            else
            {
                var old = this._performanceAmountDetailRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._performanceAmountDetailRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._performanceAmountDetailRepository.Delete(id);
        }

        public string ExportDoc1(Guid id)
        {
            return DownloadFileService.Load("履约保证金抵扣没收通知书模板.docx", "履约保证金抵扣没收通知书.docx", new string[] { })
                .ExcuteDoc(id, this.ExportToDoc1);
        }
        
        private KeyValue<DataSet, string[], object[]> ExportToDoc1(object arg)
        {
            var id        = new Guid(arg.ToString());
            var value = new[]
            {
                "项目名称",
                "中标时间",
                "保证金缴纳时间",
                "保证金金额",
                "已扣金额",
                "剩余金额",
                "情况说明",
                "部门",
                "联系人",
                "电话",
                "扣除金额",
                "中标单位",
                "日期",
            };

            var detail = this._performanceAmountDetailRepository.Get(id);
            var usedAmount = this._performanceAmountDetailRepository
                .GetAllList(r => r.PerformanceManageId == detail.PerformanceManageId
                                 && r.CreationTime<detail.CreationTime)
                .Sum(r => r.Amount);
            var performance = this._performanceManageRepository.FirstOrDefault(r => r.Id == detail.PerformanceManageId);
            var bidOping = this._bidOpeningManagementRepository.FirstOrDefault(r => r.PlanId == performance.PlanId);
            var project = this._procurementPlanRepository.Get(bidOping.PlanId);

            var item3 = new[]
            {
                project.Name,
                bidOping.Date.ToString("yyyy年MM月dd日"),
                performance.Date.ToString("yyyy年MM月dd日"),
                performance.MarginAmount.ToString(),
                usedAmount.ToString(),
                (performance.MarginAmount -usedAmount).ToString(),
                detail.Note,
                detail.Department,
                detail.User,
                detail.Phone,
                detail.Amount.ToString(),
                bidOping.SuccessfulTender,
                DateTime.Now.ToString("yyyy年MM月dd日")
            };

            var ds = new DataSet();
            var dt = new DataTable("");

            ds.Tables.Add(dt);

            return new KeyValue<DataSet, string[], object[]>(ds, value, item3);
        }
    }
}



