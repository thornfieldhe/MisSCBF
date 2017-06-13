// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBillController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Storage;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// 盘点控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CheckBillController : TAFControllerBase
    {
        private readonly ICheckBillAppService checkBillAppService;

        public CheckBillController(
            ICheckBillAppService checkBillAppService,
            IAttachmentAppService attachmentAppService,
            ISysDictionaryAppService sysDictionaryAppService)
        {
            this.checkBillAppService = checkBillAppService;
            this.attachmentAppService = attachmentAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult CheckBillList()
        {
            var list = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Material_Storage).ToList();
            return PartialView("_CheckBillIndex", list);
        }

        [HttpPost]
        public ContentResult Upload(Guid? stockId)
        {
            var billId = this.UploadFile(DictionaryCategory.Attachment_Check, stockId, this.checkBillAppService.LoadCheckFile);
            return new ContentResult() { Content = billId.ToString() };
        }
    }
}



