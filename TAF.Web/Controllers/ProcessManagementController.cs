// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessManagementController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标过程管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Http;
using SCBF.BaseInfo;

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;
    using Abp.Web.Mvc.Authorization;
    using SCBF.Purchase;

    /// <summary>
    /// 投标过程管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProcessManagementController : TAFControllerBase
    {
        private readonly IProcessManagementAppService _processManagementAppService;

        public ProcessManagementController(IProcessManagementAppService processManagementAppService,
            IAttachmentAppService    attachmentAppService,
            ISysDictionaryAppService sysDictionaryAppService)
        {
            this._processManagementAppService = processManagementAppService;
            this._attachmentAppService        = attachmentAppService;
            this._sysDictionaryAppService     = sysDictionaryAppService;
        }

        public ActionResult DesignManage()
        {
            ViewData["users"] = this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_Users);
            ViewData["units"] =
                this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_DesignUnit);
            ViewData["projects1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_DesignManage");
        }

        public ActionResult CostManage()
        {
            ViewData["users"] = this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_Users);
            ViewData["units"] =
                this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_CostUnit);
            ViewData["projects1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_CostManage");
        }

        public ActionResult SupervisionManage()
        {
            ViewData["users"] = this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_Users);
            ViewData["units"] =
                this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_ConstructionControlUnit);
            ViewData["projects1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_SupervisionManage");
        }

        public ActionResult AgentManageManage()
        {
            ViewData["users"] = this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_Users);
            ViewData["units"] =
                this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_BiddingAgency);
            ViewData["projects1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_AgentManageManage");
        }

        public ActionResult RepresentativesManage()
        {
            ViewData["users"] = this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_Users);
            ViewData["units"] =
                this._sysDictionaryAppService.GetReadOnlyList(DictionaryCategory.Purchase_PartyA);
            ViewData["projects1"] = this._processManagementAppService.GetPurchases();
            return PartialView("_RepresentativesManage");
        }

        public FileResult Print([FromUri] Guid id)
        {
            var file = this._processManagementAppService.Print(id);
            return this.DownloadFile(file);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult Upload(Guid modelId)
        {
            this.UploadFile(DictionaryCategory.Purchase_Attachment, new string[] {"_theSameFileName",modelId.ToString()},
                this._processManagementAppService.UploadAttachment);
            return new JsonResult() {Data = "OK"};
        }
    }
}
