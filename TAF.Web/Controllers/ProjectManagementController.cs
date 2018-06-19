// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Purchase;

    /// <summary>
    /// 采购过程管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProjectManagementController : TAFControllerBase
    {
        private readonly IProjectManagementAppService _projectManagementAppService;
        private readonly IProcessManagementAppService _processManagementAppService;

        public ProjectManagementController(IProjectManagementAppService projectManagementAppService,
            IProcessManagementAppService processManagementAppService)
        {
            this._projectManagementAppService = projectManagementAppService;
            this._processManagementAppService = processManagementAppService;
        }

        public ActionResult ProjectManagementList()
        {
            ViewData["list1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_ProjectManagementIndex");
        }
    }
}



