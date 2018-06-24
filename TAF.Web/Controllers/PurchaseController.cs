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
    using System.Web.Mvc;
    using Abp.Web.Mvc.Authorization;

    /// <summary>
    /// 采购控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class PurchaseController : TAFControllerBase
    {
        public PurchaseController()
        {
        }

        public ActionResult InfoList() { return this.PartialView("_PurchaseInfoIndex"); }


        public ActionResult PoolConfig()
        {
            return this.PartialView("_PoolConfig");
        }

        public ActionResult DownloadFiles()
        {
            return this.PartialView("_DownloadFiles");
        }
    }


}



