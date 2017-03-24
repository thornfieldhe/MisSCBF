// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;

    /// <summary>
    /// 入库单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class EntryBillController : TAFControllerBase
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public EntryBillController(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult EntryBillList()
        {
            var list = sysDictionaryAppService.GetSimpleList().Where(r => r.Category == DictionaryCategory.Storage).ToList();
            return PartialView("_EntryBillIndex", list);
        }
    }
}



