// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTaskController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Projects;

    /// <summary>
    /// 项目任务控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProjectTaskController : TAFControllerBase
    {
        private readonly IProjectTaskAppService projectTaskAppService;
        private readonly IProjectAppService projectAppService;

        public ProjectTaskController(IProjectTaskAppService projectTaskAppService, IProjectAppService projectAppService)
        {
            this.projectTaskAppService = projectTaskAppService;
            this.projectAppService = projectAppService;
        }

        public ActionResult ProjectTaskList()
        {
            var projects = this.projectAppService.GetSimpleList();
            return PartialView("_ProjectTaskIndex", projects);
        }
    }
}



