// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlayController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实际支出控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Finance;
    using System.Web.Mvc;

    /// <summary>
    /// 实际支出控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ActualOutlayController : TAFControllerBase
    {
        private readonly IActualOutlayAppService actualOutlayAppService;

        public ActualOutlayController(IActualOutlayAppService actualOutlayAppService
            , ISysDictionaryAppService sysDictionaryAppService
            , IAttachmentAppService attachmentAppService)
        {
            this.actualOutlayAppService = actualOutlayAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
            this.attachmentAppService = attachmentAppService;
        }

        public ActionResult ActualOutlayList()
        {
            return PartialView("_ActualOutlayIndex");
        }

        public ActionResult OutlayList()
        {
            return PartialView("_OutlayIndex");
        }

        [HttpPost]
        public JsonResult Upload()
        {
            this.UploadFile(DictionaryCategory.Attachment_ActualOutlays, new string[] { }, this.actualOutlayAppService.LoadActualOutlayFile);
            return new JsonResult() { Data = "OK" };
        }
    }
}



