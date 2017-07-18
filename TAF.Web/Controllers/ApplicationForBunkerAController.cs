// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationForBunkerAController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡申请加油审批单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TAF.Utility;

    /// <summary>
    /// 加油卡申请加油审批单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ApplicationForBunkerAController : TAFControllerBase
    {
        private readonly IOilCardAppService oilCardAppService;
        private readonly IDriverAppService driverAppService;

        public ApplicationForBunkerAController(
            IOilCardAppService oilCardAppService,
        ISysDictionaryAppService sysDictionaryAppService,
            IDriverAppService driverAppService)
        {
            this.oilCardAppService = oilCardAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
            this.driverAppService = driverAppService;
        }

        public ActionResult ApplicationForBunkerAList()
        {
            var list1 = oilCardAppService.GetSimple();
            var list2 = driverAppService.GetSimpleList();
            return PartialView("_ApplicationForBunkerAIndex", new KeyValue<List<KeyValue<string, Guid>>, List<KeyValue<Guid, string>>>(list1, list2));
        }

        public ActionResult ApplicationForBunkerAList2()
        {
            var list1 = oilCardAppService.GetSimple();
            var list2 = driverAppService.GetSimpleList();
            return PartialView("_ApplicationForBunkerAIndex2", new KeyValue<List<KeyValue<string, Guid>>, List<KeyValue<Guid, string>>>(list1, list2));
        }

        public ActionResult ApplicationForAuditAList()
        {
            ViewData["list1"] = oilCardAppService.GetSimple();
            ViewData["list2"] = driverAppService.GetSimpleList();
            ViewData["list3"] = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Car_Attendant);
            return PartialView("_ApplicationForAuditAList");
        }

        public ActionResult ApplicationForConfirmAList()
        {
            var list1 = oilCardAppService.GetSimple();
            var list2 = driverAppService.GetSimpleList();
            return PartialView("_ApplicationForConfirmAList", new KeyValue<List<KeyValue<string, Guid>>, List<KeyValue<Guid, string>>>(list1, list2));
        }
    }
}



