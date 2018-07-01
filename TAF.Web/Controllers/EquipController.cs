// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="">
//   
// </copyright>
// <summary>
//   账号控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SCBF.BaseInfo;

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    public class EquipController : TAFControllerBase
    {

        public EquipController( ISysDictionaryAppService                sysDictionaryAppService)
        {
            this._sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult EquipList() { return PartialView("_EquipList"); }

        [HttpPost]
        public JsonResult UploadImage()
        {
            var ckCsrfToken =this.Request.Params["ckCsrfToken"];
           var path= this.UploadFile(DictionaryCategory.Attachment_Equip, new string[] { }, null);
            return new JsonResult(){ Data = new CKEditorImage(){fileName = "123",uploaded = 1,url = path}};
        }

        class CKEditorImage
        {
            public string fileName { get;set; }
            public int uploaded { get;set; }
            public string url { get; set; }
        }

    }
}