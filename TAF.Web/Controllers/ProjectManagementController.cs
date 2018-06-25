// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectManagementController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   采购过程管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

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



        public FileResult Download1(Guid id)
        {
            var file = this._projectManagementAppService.ExportDoc1(id);
            return this.DownloadFile(file);
        }


        public FileResult Download2(Guid id)
        {
            var file = this._projectManagementAppService.ExportDoc2(id);
            return this.DownloadFile(file);
        }


        public FileResult DownloadReport()
        {
            var file = this._projectManagementAppService.ExportDoc3();
            return this.DownloadFile(file);
        }
    }
}



