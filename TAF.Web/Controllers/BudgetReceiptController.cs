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
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

    using Abp.UI;
    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
    using SCBF.Finance;

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
        public JsonResult Upload()
        {
            this.UploadFile(DictionaryCategory.Attachment_BudgetReceipt, this.budgetReceiptAppService.LoadBudgetReceiptFile);
            return new JsonResult() { Data = "OK" };
        }

        public ActionResult BudgetReceiptList()
        {
            return PartialView("_BudgetReceiptIndex");
        }
    }
}



