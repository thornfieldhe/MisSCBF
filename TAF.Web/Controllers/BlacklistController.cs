// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlacklistController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Purchase;

    /// <summary>
    /// 会质量评价体系控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class BlacklistController : TAFControllerBase
    {
        private readonly IBlacklistAppService _blacklistAppService;

        public BlacklistController(IBlacklistAppService blacklistAppService)
        {
            this._blacklistAppService = blacklistAppService;
        }
        
        public ActionResult BlacklistList()
        {
            return PartialView("_BlacklistIndex");
        }

        
        public FileResult Download()
        {
            var file = this._blacklistAppService.ExportDoc();
            return this.DownloadFile(file);
        }
    }
}



