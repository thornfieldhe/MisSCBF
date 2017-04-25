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
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;
    using SCBF.Finance;
    using TAF.Utility;

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
            var list = new List<KeyValue<string, Guid>>();
            return PartialView("_ActualOutlayIndex", list);
        }

        [HttpPost]
        public JsonResult Upload()
        {
            this.UploadFile(DictionaryCategory.Attachment_ActualOutlays, this.actualOutlayAppService.LoadActualOutlayFile);
            return new JsonResult() { Data = "OK" };
        }
    }
}



