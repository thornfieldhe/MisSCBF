// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarInfoController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆信息控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// 车辆信息控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CarInfoController : TAFControllerBase
    {
        private readonly ICarInfoAppService carInfoAppService;

        public CarInfoController(ICarInfoAppService carInfoAppService, ISysDictionaryAppService sysDictionaryAppService)
        {
            this.carInfoAppService = carInfoAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult CarInfoList()
        {
            var list = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_Status).ToList();
            return PartialView("_CarInfoIndex", list);
        }
    }
}



