// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   CarController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using System.Web.Mvc;

    /// <summary>
    /// 车辆控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CarController : TAFControllerBase
    {
        public CarController(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult InfoList() { return PartialView("_CarInfoIndex"); }
    }
}