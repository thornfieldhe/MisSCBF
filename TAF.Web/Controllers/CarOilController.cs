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
    using System.Web.Mvc;
    using Abp.Web.Mvc.Authorization;
    using SCBF.Car;

    /// <inheritdoc />
    /// <summary>
    /// 车辆油料核算表控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CarOilController : TAFControllerBase
    {
        /// <summary>
        /// The car info app service.
        /// </summary>
        private readonly ICarInfoAppService carInfoAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarOilController"/> class.
        /// </summary>
        /// <param name="carInfoAppService">
        /// The car info app service.
        /// </param>
        public CarOilController(ICarInfoAppService carInfoAppService)
        {
            this.carInfoAppService = carInfoAppService;
        }

        /// <summary>
        /// The car oil list.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult CarOilList()
        {
            this.ViewData["list1"] = this.carInfoAppService.GetSimple();
            return this.PartialView("_CarOilIndex");
        }

        /// <summary>
        /// The car oil list.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult TotalOilHisList()
        {
            this.ViewData["list1"] = this.carInfoAppService.GetSimple();
            return this.PartialView("_TotalOilHisList");
        }
    }
}



