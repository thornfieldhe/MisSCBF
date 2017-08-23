// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarOilController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆油料核算表控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 车辆油料核算表控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CarOilController : TAFControllerBase
    {
        private readonly ICarOilAppService carOilAppService;
        private readonly ICarInfoAppService carInfoAppService;

        public CarOilController(ICarOilAppService carOilAppService, ICarInfoAppService carInfoAppService)
        {
            this.carOilAppService = carOilAppService;
            this.carInfoAppService = carInfoAppService;
        }

        public ActionResult CarOilList()
        {
            ViewData["list1"] = carInfoAppService.GetSimple();
            return PartialView("_CarOilIndex");
        }
    }
}



