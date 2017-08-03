// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 车辆送修申请单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ApplyForVehicleMaintenanceController : TAFControllerBase
    {
        private readonly IApplyForVehicleMaintenanceAppService applyForVehicleMaintenanceAppService;
        private readonly IDriverAppService driverAppService;
        private readonly ICarInfoAppService carInfoAppService;

        public ApplyForVehicleMaintenanceController(
            IApplyForVehicleMaintenanceAppService applyForVehicleMaintenanceAppService,
            IDriverAppService driverAppService,
            ICarInfoAppService carInfoAppService
            )
        {
            this.applyForVehicleMaintenanceAppService = applyForVehicleMaintenanceAppService;
            this.driverAppService = driverAppService;
            this.carInfoAppService = carInfoAppService;
        }

        public ActionResult ApplyForVehicleMaintenanceList()
        {
            ViewData["list1"] = driverAppService.GetSimpleList();
            ViewData["list2"] = carInfoAppService.GetSimple();
            return PartialView("_ApplyForVehicleMaintenanceIndex");
        }

        public ActionResult AudingForVehicleMaintenanceList()
        {
            ViewData["list1"] = driverAppService.GetSimpleList();
            ViewData["list2"] = carInfoAppService.GetSimple();
            return PartialView("_AudingForVehicleMaintenanceIndex");
        }
    }
}



