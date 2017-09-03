// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 发票录入控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class InvoiceCheckController : TAFControllerBase
    {
        private readonly IInvoiceCheckAppService _invoiceCheckAppService;

        public InvoiceCheckController(IInvoiceCheckAppService invoiceCheckAppService)
        {
            this._invoiceCheckAppService = invoiceCheckAppService;
        }
        
        public ActionResult InvoiceCheckList()
        {
            return PartialView("_InvoiceCheckIndex");
        }
    }
}



