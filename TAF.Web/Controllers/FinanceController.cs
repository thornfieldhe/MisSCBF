// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FinanceController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   FinanceController
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;

    /// <summary>
    /// 预算控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class FinanceController : TAFControllerBase
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public FinanceController(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult InfoList() { return PartialView("_FinanceInfoIndex"); }

        public ActionResult AccountList() { return PartialView("_AccountList"); }
    }
}