// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Projects;

    /// <summary>
    /// 工作日志控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class DailyLogController : TAFControllerBase
    {
        private readonly IDailyLogAppService dailyLogAppService;
        private readonly IProjectAppService projectAppService;

        public DailyLogController(IDailyLogAppService dailyLogAppService, IProjectAppService projectAppService)
        {
            this.dailyLogAppService = dailyLogAppService;
            this.projectAppService = projectAppService;
        }

        public ActionResult DailyLogList()
        {
            var list = projectAppService.GetSimpleList();
            return PartialView("_DailyLogIndex", list);
        }

        public ActionResult DailyLogSummary()
        {
            return PartialView("_DailyLogSummary");
        }
    }
}



