// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcurementPlanController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购计划预算关联表控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using BaseInfo;
    using Purchase;

    /// <summary>
    /// 采购计划预算关联表控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProcurementPlanController : TAFControllerBase
    {
        private readonly IProcurementPlanAppService _procurementPlanAppService;

        public ProcurementPlanController(IProcurementPlanAppService procurementPlanAppService, ISysDictionaryAppService sysDictionaryAppService)
        {
            this._procurementPlanAppService = procurementPlanAppService;
            this._sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult ProcurementPlanList()
        {
            this.ViewData["list1"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Unit);
            this.ViewData["list2"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Users);
            return this.PartialView("_ProcurementPlanIndex");
        }
        public ActionResult ProcurementPlanList1()
        {
            this.ViewData["list1"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Unit);
            this.ViewData["list2"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Users);
            return this.PartialView("_ProcurementPlanIndex1");
        }

        public ActionResult ProcurementPlanList2()
        {
            this.ViewData["list1"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Unit);
            this.ViewData["list2"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Users);
            return this.PartialView("_ProcurementPlanIndex2");
        }

        public ActionResult ProcurementPlanListSummary()
        {
            this.ViewData["list1"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Unit);
            this.ViewData["list2"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Users);
            return this.PartialView("_ProcurementPlanIndexSummary");
        }

        public FileResult DownloadPlan()
        {
            var file =  this._procurementPlanAppService.ExportExs();
            return    this.DownloadFile(file);
        }

        public FileResult DownloadReport()
        {
            var file = this._procurementPlanAppService.ExportDoc();
            return    this.DownloadFile(file);
        }
    }
}



