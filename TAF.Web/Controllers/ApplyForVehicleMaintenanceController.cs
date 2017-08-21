// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable All


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

        public ActionResult AudingForVehicleMaintenanceList2()
        {
            return PartialView("_AudingForVehicleMaintenance2Index");
        }

        public ActionResult AudingForVehicleMaintenanceList3()
        {
            return PartialView("_AudingForVehicleMaintenance3Index");
        }

        public ActionResult VehicleMaintenanceReport()
        {
            return PartialView("_VehicleMaintenanceReport");
        }
    }
}



