// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTaskController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.BaseInfo;
    
    /// <summary>
    /// 计划任务控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ScheduledTaskController : TAFControllerBase
    {
        private readonly IScheduledTaskAppService scheduledTaskAppService;

        public ScheduledTaskController(IScheduledTaskAppService scheduledTaskAppService)
        {
            this.scheduledTaskAppService = scheduledTaskAppService;
        }
        
        public ActionResult ScheduledTaskList()
        {
            return PartialView("_ScheduledTaskIndex");
        }
    }
}



