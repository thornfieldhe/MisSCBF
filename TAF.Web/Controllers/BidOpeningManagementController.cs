// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BidOpeningManagementController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   开标管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SCBF.BaseInfo;

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Purchase;

    /// <summary>
    /// 开标管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class BidOpeningManagementController : TAFControllerBase
    {
        private readonly IBidOpeningManagementAppService _bidOpeningManagementAppService;
        private readonly IProcessManagementAppService _processManagementAppService;

        public BidOpeningManagementController(IBidOpeningManagementAppService bidOpeningManagementAppService,
            ISysDictionaryAppService     sysDictionaryAppService,
            IProcessManagementAppService processManagementAppService)
        {
            this._bidOpeningManagementAppService = bidOpeningManagementAppService;
            this._sysDictionaryAppService = sysDictionaryAppService;
            this._processManagementAppService = processManagementAppService;
        }

        public ActionResult BidOpeningManagementList()
        {
            ViewData["list1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_BidOpeningManagementIndex");
        }
    }
}



