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
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Finance;
    using System.Web.Mvc;

    /// <summary>
    /// 年度预算收入控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class BudgetReceiptController : TAFControllerBase
    {
        private readonly IBudgetReceiptAppService budgetReceiptAppService;


        public BudgetReceiptController(IBudgetReceiptAppService budgetReceiptAppService
            , IAttachmentAppService attachmentAppService
            , ISysDictionaryAppService sysDictionaryAppService)
        {
            this.budgetReceiptAppService = budgetReceiptAppService;
            this.attachmentAppService = attachmentAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        [HttpPost]
        public JsonResult Upload1()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, null, this.budgetReceiptAppService.LoadBudgetReceiptFile1);
            return new JsonResult() { Data = "OK" };
        }

        [HttpPost]
        public JsonResult Upload2()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, null, this.budgetReceiptAppService.LoadBudgetReceiptFile2);
            return new JsonResult() { Data = "OK" };
        }

        [HttpPost]
        public JsonResult Upload3()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, null, this.budgetReceiptAppService.LoadBudgetReceiptFile3);
            return new JsonResult() { Data = "OK" };
        }

        public ActionResult BudgetReceiptList()
        {
            return PartialView("_BudgetReceiptIndex");
        }

        public ActionResult BudgetReceiptList2()
        {
            return PartialView("_BudgetReceiptIndex2");
        }

        public ActionResult BudgetReceiptList3()
        {
            return PartialView("_BudgetReceiptIndex3");
        }

        public ActionResult ReceiptList()
        {
            return PartialView("_ReceiptIndex");
        }

    }
}



