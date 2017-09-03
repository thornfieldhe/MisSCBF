// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VoucherAuditController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   凭证审核归纳表控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 凭证审核归纳表控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class VoucherAuditController : TAFControllerBase
    {
        private readonly IVoucherAuditAppService _voucherAuditAppService;

        public VoucherAuditController(IVoucherAuditAppService voucherAuditAppService)
        {
            this._voucherAuditAppService = voucherAuditAppService;
        }
        
        public ActionResult VoucherAuditList()
        {
            return PartialView("_VoucherAuditIndex");
        }
    }
}



