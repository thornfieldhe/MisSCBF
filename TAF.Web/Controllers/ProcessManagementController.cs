// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Http;
using SCBF.BaseInfo;

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;
    using Abp.Web.Mvc.Authorization;
    using SCBF.Purchase;

    /// <summary>
    /// 投标过程管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProcessManagementController : TAFControllerBase
    {
        private readonly IProcessManagementAppService _processManagementAppService;
        private readonly ISysDictionaryAppService     _sysDictionaryAppService;

        public ProcessManagementController(IProcessManagementAppService processManagementAppService,
            ISysDictionaryAppService                                    sysDictionaryAppService)
        {
            this._processManagementAppService = processManagementAppService;
            this._sysDictionaryAppService     = sysDictionaryAppService;
        }

        public ActionResult DesignManage()
        {
            ViewData["users"] = this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_Users);
            ViewData["units"] =
                this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_DesignUnit);
            ViewData["projects1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_DesignManage");
        }

        public FileResult Print([FromUri]Guid id)
        {
            var file = this._processManagementAppService.Print(id);
            return    this.DownloadFile(file);
        }
    }
}
