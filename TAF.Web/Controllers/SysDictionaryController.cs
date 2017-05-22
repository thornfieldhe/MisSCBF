// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using SCBF.BaseInfo;
    using System.Collections.Generic;
    using System.Web.Mvc;

    /// <summary>
    /// 系统配置控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class SysDictionaryController : TAFControllerBase
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public SysDictionaryController(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult SysDictionaryList()
        {
            var list = new List<string>()
            {
                DictionaryCategory.Material_ProductCategory,
                DictionaryCategory.Material_ProductUnit,
                DictionaryCategory.Material_Storage,
                DictionaryCategory.Budget_Year,
                DictionaryCategory.Budget_Account,
                DictionaryCategory.Attachment_BashPath,
                DictionaryCategory.Attachment_BudgetReceipt,
                DictionaryCategory.Attachment_BudgetOutlays,
                DictionaryCategory.Attachment_Ext
            };
            return PartialView("_SysDictionaryIndex", list);
        }
    }
}



