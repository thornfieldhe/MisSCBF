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
    using SCBF.BaseInfo;
    using SCBF.Storage;
    using System.Web.Mvc;

    /// <summary>
    /// 商品控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProductController : TAFControllerBase
    {
        private readonly IProductAppService productAppService;
        private readonly ISysDictionaryAppService sysDictionaryAppService;
        private readonly ILayerAppService layerAppService;

        public ProductController(IProductAppService productAppService, ISysDictionaryAppService sysDictionaryAppService, ILayerAppService layerAppService)
        {
            this.productAppService = productAppService;
            this.sysDictionaryAppService = sysDictionaryAppService;
            this.layerAppService = layerAppService;
        }

        public ActionResult ProductList()
        {
            var list = sysDictionaryAppService.GetSimpleList(DictionaryCategory.Material_ProductUnit);
            return PartialView("_ProductIndex", list);
        }

        public ActionResult InfoList() { return PartialView("_ProductInfoIndex"); }
    }
}



