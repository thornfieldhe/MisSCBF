// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.BaseInfo;
    
    /// <summary>
    /// 系统配置控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class SysDictionaryController : TAFControllerBase
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public SysDictionaryController(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }
        
        public ActionResult SysDictionaryList()
        {
            return PartialView("_SysDictionaryIndex");
        }
    }
}



