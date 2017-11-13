// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoeController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购阶段控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Purchase;
    using TAF.Utility;

    /// <summary>
    /// 采购阶段控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class StageInfoeController : TAFControllerBase
    {
        private readonly IStageInfoeAppService _stageInfoeAppService;

        public StageInfoeController(IStageInfoeAppService stageInfoeAppService)
        {
            this._stageInfoeAppService = stageInfoeAppService;
        }

        public ActionResult StageInfoeList()
        {
            ViewData["list1"] = new List<KeyValue<string, Guid>>();
            return PartialView("_StageInfoeIndex");
        }
    }
}



