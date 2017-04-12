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
        private readonly IAttachmentAppService attachmentAppService;
        private readonly ISysDictionaryAppService sysDictionaryAppService;

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
            var fileData = this.Request.Files[0];
            if (fileData != null)
            {
                var defaultPath = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Attachment_BashPath);
                if (defaultPath.Count > 0)
                {
                    var virPath =
                 $"{defaultPath[0].Value}/{this.sysDictionaryAppService.GetModulePath(DictionaryCategory.Attachment_BudgetReceipt)}/";
                    var fileSaveLocation = Server.MapPath(virPath);
                    if (!Directory.Exists(fileSaveLocation))
                    {
                        Directory.CreateDirectory(fileSaveLocation);
                    }

                    string fileName = Path.GetFileName(fileData.FileName);// 原始文件名称
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名

                    var fileTypes = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Attachment_Ext);
                    if (fileTypes.Count == 0)
                    {
                        throw new UserFriendlyException("未配置允许上传附件格式");
                    }
                    if (string.IsNullOrEmpty(fileExtension) || Array.IndexOf(fileTypes[0].Value.Split(','), fileExtension.ToLower()) == -1)
                    {
                        throw new UserFriendlyException("不允许上传该格式附件");
                    }
                    else
                    {
                        string saveName = Guid.NewGuid() + fileExtension; // 保存文件名称
                        fileData.SaveAs(fileSaveLocation + saveName);


                        var modelId = Guid.NewGuid();

                        this.attachmentAppService.Save(new AttachmentEditDto()
                        {
                            Name = saveName,
                            Category = DictionaryCategory.Attachment_BudgetReceipt,
                            Ext = fileExtension,
                            ModuleId = modelId,
                            Path = $"{this.sysDictionaryAppService.GetModulePath(DictionaryCategory.Attachment_BudgetReceipt)}/{saveName}",
                            Size = (decimal)fileData.ContentLength / 1024
                        });
                    }

                }
                else
                {
                    throw new UserFriendlyException("未配置默认上传路径");
                }
            }
            return new JsonResult() { Data = "OK" };
        }

        public ActionResult BudgetReceiptList()
        {
            return PartialView("_BudgetReceiptIndex");
        }
    }
}



