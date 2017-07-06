// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardProofController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.Car;
    
    /// <summary>
    /// 加油卡消耗凭证单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class OilCardProofController : TAFControllerBase
    {
        private readonly IOilCardProofAppService oilCardProofAppService;

        public OilCardProofController(IOilCardProofAppService oilCardProofAppService)
        {
            this.oilCardProofAppService = oilCardProofAppService;
        }
        
        public ActionResult OilCardProofList()
        {
            return PartialView("_OilCardProofIndex");
        }
    }
}



