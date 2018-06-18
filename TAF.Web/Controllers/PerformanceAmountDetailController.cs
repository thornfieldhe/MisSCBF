// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceAmountDetailController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   履约保证金管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Purchase;

    /// <summary>
    /// 履约保证金管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class PerformanceAmountDetailController : TAFControllerBase
    {
        private readonly IPerformanceAmountDetailAppService _performanceAmountDetailAppService;

        public PerformanceAmountDetailController(IPerformanceAmountDetailAppService performanceAmountDetailAppService)
        {
            this._performanceAmountDetailAppService = performanceAmountDetailAppService;
        }
        
        public FileResult Download(Guid id)
        {
            var file = this._performanceAmountDetailAppService.ExportDoc1(id);
            return this.DownloadFile(file);
        }
    }
}



