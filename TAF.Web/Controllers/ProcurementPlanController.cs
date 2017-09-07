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

    using SCBF.BaseInfo;
    using SCBF.Purchase;

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
            ViewData["list1"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Unit);
            ViewData["list2"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_Users);
            return PartialView("_ProcurementPlanIndex");
        }
    }
}



