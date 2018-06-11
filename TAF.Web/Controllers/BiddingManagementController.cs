// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiddingManagementController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标文件管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SCBF.BaseInfo;

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Purchase;

    /// <summary>
    /// 招标文件管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class BiddingManagementController : TAFControllerBase
    {
        private readonly IBiddingManagementAppService _biddingManagementAppService;
        private readonly IProcessManagementAppService _processManagementAppService;

        public BiddingManagementController(IBiddingManagementAppService biddingManagementAppService,
            ISysDictionaryAppService sysDictionaryAppService,
            IProcessManagementAppService processManagementAppService)
        {
            this._biddingManagementAppService = biddingManagementAppService;
            this._processManagementAppService = processManagementAppService;
            this._sysDictionaryAppService = sysDictionaryAppService;
        }
        
        public ActionResult BiddingManagementList()
        {
            ViewData["list1"] = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Purchase_BiddingAgency);
            ViewData["list2"] = this._processManagementAppService.GetPurchases();
            return PartialView("_BiddingManagementIndex");
        }
    }
}



