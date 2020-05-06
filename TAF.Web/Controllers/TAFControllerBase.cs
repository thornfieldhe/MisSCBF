using System.Web;
using System.Web.Mvc;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using Microsoft.AspNet.Identity;

namespace SCBF.Web.Controllers
{
    using System;
    using System.IO;
    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class TAFControllerBase : AbpController
    {
        protected IAttachmentAppService    _attachmentAppService;
        protected ISysDictionaryAppService _sysDictionaryAppService;

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
        /// <param name="param">第0条应该是保存文件名称</param>
        /// <param name="act"></param>
        protected string UploadFile(string category, string[] param, Func<string, object, Guid> act) //Todo: 上传文件方法已经实现
        {
            var fileData = this.Request.Files[0];
            if (fileData != null)
            {
                var defaultPath = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Attachment_BashPath);
                if (defaultPath.Count > 0)
                {
                    var virPath =
                        $"{defaultPath[0].Value}/{this._sysDictionaryAppService.GetModulePath(category)}/";
                    var fileSaveLocation = Server.MapPath(virPath);
                    if (!Directory.Exists(fileSaveLocation))
                    {
                        Directory.CreateDirectory(fileSaveLocation);
                    }

                    var fileName      = Path.GetFileName(fileData.FileName); // 原始文件名称
                    var fileExtension = Path.GetExtension(fileName);         // 文件扩展名

                    var fileTypes = this._sysDictionaryAppService.GetSimpleList(DictionaryCategory.Attachment_Ext);
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
                        var saveName = param.Length==0||param[0]!="_theSameFileName"
                            ?Guid.NewGuid() + fileExtension:fileName ; // 保存文件名称
                        var newFileName = fileSaveLocation + saveName;
                        fileData.SaveAs(newFileName);     // 
                        var fileInfo = new FileInfo(newFileName);

                        if (act != null)
                        {
                            var modelId = act(newFileName, param);
                            this._attachmentAppService.Save(
                                new AttachmentEditDto()
                                {
                                    Name     = fileName,
                                    Category = category,
                                    Ext      = fileExtension,
                                    Path     = $"{this._sysDictionaryAppService.GetModulePath(category)}/{saveName}",
                                    Size     = (decimal) fileInfo.Length / 1024,
                                    ModelId  = modelId
                                });
                            return modelId.ToString();
                        }
                        return (virPath +saveName).Replace("~","").Replace("/",@"\");
                    }
                }
                else
                {
                    throw new UserFriendlyException("未配置默认上传路径");
                }
            }

            throw new UserFriendlyException("未上传文件");
        }

        protected FileResult DownloadFile(string path)
        {
            var fi = new FileInfo(path);
            var s  = MimeMapping.GetMimeMapping(fi.Name);
            return File(path, s, Path.GetFileName(path));
        }
    }
}
