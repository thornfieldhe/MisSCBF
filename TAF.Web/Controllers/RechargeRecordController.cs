// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RechargeRecordController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.Car;
    using System.Web.Mvc;

    /// <summary>
    /// 油料分配记录控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class RechargeRecordController : TAFControllerBase
    {
        private readonly IOilCardAppService oilCardAppService;

        public RechargeRecordController(IOilCardAppService oilCardAppService)
        {
            this.oilCardAppService = oilCardAppService;
        }

        public ActionResult RechargeRecordList()
        {
            var list = this.oilCardAppService.GetSimple();
            return PartialView("_RechargeRecordIndex", list);
        }
    }
}



