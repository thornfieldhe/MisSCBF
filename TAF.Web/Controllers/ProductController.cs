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
    
    using SCBF.Storage;
    
    /// <summary>
    /// 商品控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class ProductController : TAFControllerBase
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }
        
        public ActionResult ProductList()
        {
            return PartialView("_ProductIndex");
        }
    }
}



