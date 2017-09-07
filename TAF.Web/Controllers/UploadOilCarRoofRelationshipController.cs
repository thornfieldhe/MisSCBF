// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadOilCarRoofRelationshipController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using SCBF.Car;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TAF.Utility;

    /// <summary>
    /// 加油卡消耗凭证单单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class UploadOilCarRoofRelationshipController : TAFControllerBase
    {
        private readonly IOilCardProofAppService oilCardProofAppService;

        public UploadOilCarRoofRelationshipController(
            IOilCardProofAppService oilCardProofAppService,
            ISysDictionaryAppService sysDictionaryAppService,
                                                      IAttachmentAppService attachmentAppService)
        {
            this.oilCardProofAppService = oilCardProofAppService;
            this._sysDictionaryAppService = sysDictionaryAppService;
            this._attachmentAppService = attachmentAppService;
        }


        [System.Web.Mvc.HttpPost]
        public JsonResult Upload(string month)
        {
            this.UploadFile(DictionaryCategory.Attachment_OilCardProof, new string[] { month }, this.oilCardProofAppService.LoadProofFile);
            return new JsonResult() { Data = "OK" };
        }

        public ActionResult UploadOilCarRoofRelationshipList()
        {
            ViewData["list1"] = new List<KeyValue<string, Guid>>();
            return PartialView("_UploadOilCarRoofRelationshipIndex");
        }
    }
}



