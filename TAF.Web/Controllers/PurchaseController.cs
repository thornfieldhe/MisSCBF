// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using Abp.Web.Mvc.Authorization;
    using System.Web.Mvc;

    /// <summary>
    /// 采购控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class PurchaseController : TAFControllerBase
    {
        public PurchaseController()
        {
        }

        public ActionResult InfoList() { return PartialView("_PurchaseInfoIndex"); }
    }
}



