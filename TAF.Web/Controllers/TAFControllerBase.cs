using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace SCBF.Web.Controllers
{
    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;
    using System;
    using System.IO;

    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class TAFControllerBase : AbpController
    {
        protected IAttachmentAppService attachmentAppService;
        protected ISysDictionaryAppService sysDictionaryAppService;

        protected TAFControllerBase()
        {
            LocalizationSourceName = TAFConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        /// <summary>
        /// 通用上传模块
        /// </summary>
        /// <param name="category"></param>
        /// <param name="param"></param>
        /// <param name="act"></param>
        protected Guid UploadFile(string category, string[] param, Func<string, object, Guid> act)
        {
            var fileData = this.Request.Files[0];
            if (fileData != null)
            {
                var defaultPath = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Attachment_BashPath);
                if (defaultPath.Count > 0)
                {
                    var virPath = $"{defaultPath[0].Value}/{this.sysDictionaryAppService.GetModulePath(category)}/";
                    var fileSaveLocation = Server.MapPath(virPath);
                    if (!Directory.Exists(fileSaveLocation))
                    {
                        Directory.CreateDirectory(fileSaveLocation);
                    }

                    string fileName = Path.GetFileName(fileData.FileName); // 原始文件名称
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名

                    var fileTypes = this.sysDictionaryAppService.GetSimpleList(DictionaryCategory.Attachment_Ext);
                    if (fileTypes.Count == 0)
                    {
                        throw new UserFriendlyException("未配置允许上传附件格式");
                    }

                    if (string.IsNullOrEmpty(fileExtension)
                       || Array.IndexOf(fileTypes[0].Value.Split(','), fileExtension.ToLower()) == -1)
                    {
                        throw new UserFriendlyException("不允许上传该格式附件");
                    }
                    else
                    {
                        var saveName = Guid.NewGuid() + fileExtension; // 保存文件名称
                        fileData.SaveAs(fileSaveLocation + saveName);
                        var fileInfo = new FileInfo(fileSaveLocation + saveName);


                        var modelId = act(fileSaveLocation + saveName, param);
                        this.attachmentAppService.Save(
                             new AttachmentEditDto()
                             {
                                 Name = saveName,
                                 Category = category,
                                 Ext = fileExtension,
                                 ModuleId = modelId,
                                 Path = $"{this.sysDictionaryAppService.GetModulePath(category)}/{saveName}",
                                 Size = (decimal)fileInfo.Length / 1024
                             });
                        return modelId;
                    }
                }
                else
                {
                    throw new UserFriendlyException("未配置默认上传路径");
                }
            }
            throw new UserFriendlyException("未上传文件");
        }
    }
}