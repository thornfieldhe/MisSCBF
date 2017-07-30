// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerAController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 加油卡申请加油审批单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ApplicationForBunkerBController : TAFControllerBase
    {
        private readonly IOctaneStoreAppService octaneStoreAppService;
        private readonly IDriverAppService driverAppService;
        private readonly ICarInfoAppService carInfoAppService;

        public ApplicationForBunkerBController(
            IOctaneStoreAppService octaneStoreAppService,
        ISysDictionaryAppService sysDictionaryAppService,
            IDriverAppService driverAppService,
            ICarInfoAppService carInfoAppService)
        {
            this.octaneStoreAppService = octaneStoreAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
            this.driverAppService = driverAppService;
            this.carInfoAppService = carInfoAppService;
        }

        public ActionResult ApplicationForBunkerBList()
        {
            ViewData["list1"] = octaneStoreAppService.GetSimple();
            ViewData["list2"] = driverAppService.GetSimpleList();
            ViewData["list3"] = carInfoAppService.GetSimple();
            return PartialView("_ApplicationForBunkerBIndex");
        }

        public ActionResult ApplicationForBunkerBList2()
        {
            ViewData["list1"] = octaneStoreAppService.GetSimple();
            ViewData["list2"] = driverAppService.GetSimpleList();
            ViewData["list3"] = carInfoAppService.GetSimple();
            return PartialView("_ApplicationForBunkerBIndex2");
        }

        public ActionResult ApplicationForAuditBList()
        {
            ViewData["list1"] = octaneStoreAppService.GetSimple();
            ViewData["list3"] = driverAppService.GetSimpleList();
            ViewData["list2"] = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_Attendant);
            return PartialView("_ApplicationForAuditBList");
        }

        public ActionResult CheckApplicationForBunkerList()
        {
            return PartialView("_CheckApplicationForBunkerList");
        }
    }
}



