// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriverController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   驾驶员控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 驾驶员控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class DriverController : TAFControllerBase
    {
        private readonly IDriverAppService driverAppService;

        public DriverController(
            IDriverAppService driverAppService,
            ISysDictionaryAppService sysDictionaryAppService)
        {
            this.driverAppService = driverAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult DriverList()
        {
            var list = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_DriveLevel);
            return PartialView("_DriverIndex", list);
        }
    }
}



