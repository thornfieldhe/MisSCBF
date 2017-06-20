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
    using SCBF.BaseInfo.Dto;
    using SCBF.Car;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TAF.Utility;

    /// <summary>
    /// 车辆信息控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CarInfoController : TAFControllerBase
    {
        private readonly IDriverAppService driverAppService;

        public CarInfoController(IDriverAppService driverAppService, ISysDictionaryAppService sysDictionaryAppService)
        {
            this.driverAppService = driverAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult CarInfoList()
        {
            var list1 = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_Status).ToList();
            var list2 = driverAppService.GetSimpleList();
            var list3 = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_OctaneRating).ToList();
            return PartialView("_CarInfoIndex", new KeyValue<List<SysDictionaryListDto>, List<KeyValue<Guid, string>>, List<SysDictionaryListDto>>(list1, list2, list3));
        }
    }
}



