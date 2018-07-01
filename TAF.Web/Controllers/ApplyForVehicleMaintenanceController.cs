// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplyForVehicleMaintenanceController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆送修申请单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable All


using SCBF.BaseInfo;

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;
    using Abp.Web.Mvc.Authorization;
    using SCBF.Car;

    /// <summary>
    /// 车辆送修申请单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ApplyForVehicleMaintenanceController : TAFControllerBase
    {
        private readonly IApplyForVehicleMaintenanceAppService _applyForVehicleMaintenanceAppService;
        private readonly IDriverAppService _driverAppService;
        private readonly ICarInfoAppService _carInfoAppService;

        public ApplyForVehicleMaintenanceController(
            IApplyForVehicleMaintenanceAppService applyForVehicleMaintenanceAppService,
            IDriverAppService driverAppService,
            ISysDictionaryAppService sysDictionaryAppService,
            ICarInfoAppService carInfoAppService
            )
        {
            this._applyForVehicleMaintenanceAppService = applyForVehicleMaintenanceAppService;
            this._driverAppService = driverAppService;
            this._carInfoAppService = carInfoAppService;
            this._sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult ApplyForVehicleMaintenanceList()
        {
            ViewData["list1"] = this._driverAppService.GetSimpleList();
            ViewData["list2"] = this._carInfoAppService.GetSimple();
            ViewData["list3"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_ServiceDepot);
            return PartialView("_ApplyForVehicleMaintenanceIndex");
        }

        public ActionResult AudingForVehicleMaintenanceList()
        {
            ViewData["list1"] = this._driverAppService.GetSimpleList();
            ViewData["list2"] = this._carInfoAppService.GetSimple();
            ViewData["list3"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_ServiceDepot);
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



