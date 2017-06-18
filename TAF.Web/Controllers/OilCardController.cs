// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料卡控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 油料卡控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class OilCardController : TAFControllerBase
    {
        private readonly ICarInfoAppService carInfoAppService;

        public OilCardController(ICarInfoAppService carInfoAppService)
        {
            this.carInfoAppService = carInfoAppService;
        }

        public ActionResult OilCardList()
        {
            var list = carInfoAppService.GetSimple();
            return PartialView("_OilCardIndex", list);
        }
    }
}



