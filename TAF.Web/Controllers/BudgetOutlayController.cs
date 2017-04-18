// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   支出预算控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;
    using SCBF.Finance;

    /// <summary>
    /// 支出预算控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class BudgetOutlayController : TAFControllerBase
    {
        private readonly IBudgetOutlayAppService budgetOutlayAppService;

        public BudgetOutlayController(IBudgetOutlayAppService budgetOutlayAppService
            , IAttachmentAppService attachmentAppService
            , ISysDictionaryAppService sysDictionaryAppService)
        {
            this.budgetOutlayAppService = budgetOutlayAppService;
            this.attachmentAppService = attachmentAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        [HttpPost]
        public JsonResult Upload()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, this.budgetOutlayAppService.LoadBudgetReceiptFile);
            return new JsonResult() { Data = "OK" };
        }

        public ActionResult BudgetOutlayList()
        {
            return PartialView("_BudgetOutlayIndex");
        }
    }
}



