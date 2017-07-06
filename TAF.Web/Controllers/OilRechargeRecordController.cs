// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilRechargeRecordController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 实物油料入库单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class OilRechargeRecordController : TAFControllerBase
    {

        private readonly IOilRechargeRecordAppService oilRechargeRecordAppService;

        public OilRechargeRecordController(IOilRechargeRecordAppService oilRechargeRecordAppService, ISysDictionaryAppService sysDictionaryAppService)
        {
            this.oilRechargeRecordAppService = oilRechargeRecordAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult OilRechargeRecordList()
        {
            ViewData["list1"] = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_OilHostingUnit);
            ViewData["list2"] = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_OctaneRating);
            return PartialView("_OilRechargeRecordIndex");
        }
    }
}



