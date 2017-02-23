// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.BaseInfo;

    /// <summary>
    /// 商品类别控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class StorageController : TAFControllerBase
    {
        private readonly ILayerAppService layerAppService;

        public StorageController(ILayerAppService layerAppService)
        {
            this.layerAppService = layerAppService;
        }

        public ActionResult ProductCategoryList()
        {
            return PartialView("_ProductCategoryIndex");
        }
    }
}



