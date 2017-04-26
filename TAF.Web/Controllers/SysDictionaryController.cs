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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;

    using TAF.Utility;

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
                DictionaryCategory.Mmaterial_ProductCategory,
                DictionaryCategory.Mmaterial_ProductUnit,
                DictionaryCategory.Mmaterial_Storage,
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



