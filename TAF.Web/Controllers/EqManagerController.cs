// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqManagerController.cs" company="" author="何翔华">
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
    public class EqManagerController : TAFControllerBase
    {
        private readonly IEqManagerAppService _eqManagerAppService;
        private readonly IProcessManagementAppService _processManagementAppService;

        public EqManagerController(IEqManagerAppService eqManagerAppService,
            IProcessManagementAppService processManagementAppService)
        {
            this._eqManagerAppService = eqManagerAppService;
            this._processManagementAppService = processManagementAppService;
        }
        
        public ActionResult EqManagerList()
        {
            ViewData["list1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_EqManagerIndex");
        }
    }
}



