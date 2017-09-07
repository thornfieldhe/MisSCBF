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
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Finance;
    using System.Web.Mvc;

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
            this._attachmentAppService = attachmentAppService;
            this._sysDictionaryAppService = sysDictionaryAppService;
        }

        [HttpPost]
        public JsonResult Upload1()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, new string[] { }, this.budgetOutlayAppService.LoadBudgetReceiptFile1);
            return new JsonResult() { Data = "OK" };
        }

        [HttpPost]
        public JsonResult Upload2()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, new string[] { }, this.budgetOutlayAppService.LoadBudgetReceiptFile2);
            return new JsonResult() { Data = "OK" };
        }

        [HttpPost]
        public JsonResult Upload3()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, new string[] { }, this.budgetOutlayAppService.LoadBudgetReceiptFile3);
            return new JsonResult() { Data = "OK" };
        }

        public ActionResult BudgetOutlayList()
        {
            return PartialView("_BudgetOutlayIndex");
        }

        public ActionResult BudgetOutlayList2()
        {
            return PartialView("_BudgetOutlayIndex2");
        }

        public ActionResult BudgetOutlayList3()
        {
            return PartialView("_BudgetOutlayIndex3");
        }

        public ActionResult BudgetSummary()
        {
            return PartialView("_BudgetSummary");
        }

        public ActionResult BudgetPerformance()
        {
            return PartialView("_BudgetPerformance");
        }
    }
}



