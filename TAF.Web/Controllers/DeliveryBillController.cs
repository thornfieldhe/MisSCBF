// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryBillController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   出库单控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;

    /// <summary>
    /// 出库单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class DeliveryBillController : TAFControllerBase
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public DeliveryBillController(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public ActionResult DeliveryBillList()
        {
            var list = sysDictionaryAppService.GetSimpleList().Where(r => r.Category == DictionaryCategory.Storage).ToList();
            return PartialView("_DeliveryBillIndex", list);
        }
    }
}



