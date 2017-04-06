// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetReceiptController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   年度预算收入控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.Finance;
    
    /// <summary>
    /// 年度预算收入控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class BudgetReceiptController : TAFControllerBase
    {
        private readonly IBudgetReceiptAppService budgetReceiptAppService;

        public BudgetReceiptController(IBudgetReceiptAppService budgetReceiptAppService)
        {
            this.budgetReceiptAppService = budgetReceiptAppService;
        }
        
        public ActionResult BudgetReceiptList()
        {
            return PartialView("_BudgetReceiptIndex");
        }
    }
}



