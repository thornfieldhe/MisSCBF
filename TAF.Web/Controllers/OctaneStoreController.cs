// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OctaneStoreController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料库控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
    using SCBF.Car;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TAF.Utility;

    /// <summary>
    /// 实物油料库控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class OctaneStoreController : TAFControllerBase
    {
        private readonly IOctaneStoreAppService octaneStoreAppService;

        public OctaneStoreController(IOctaneStoreAppService octaneStoreAppService, ISysDictionaryAppService sysDictionaryAppService)
        {
            this.octaneStoreAppService = octaneStoreAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult OctaneStoreList()
        {
             ViewData["list1"] = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_OilHostingUnit);
            ViewData["list2"]  = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_OctaneRating);
            return PartialView("_OctaneStoreIndex");
        }
    }
}



