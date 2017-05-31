// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HisStockController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   历史库存控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;

    using SCBF.Storage;
    using TAF.Utility;

    /// <summary>
    /// 历史库存控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class HisStockController : TAFControllerBase
    {
        private readonly IHisStockAppService hisStockAppService;

        public HisStockController(IHisStockAppService hisStockAppService)
        {
            this.hisStockAppService = hisStockAppService;
        }

        public ActionResult HisStockList()
        {
            return PartialView("_HisStockIndex");
        }

        public ActionResult QueryStockList()
        {
            return PartialView("_QueryStockList");
        }
        public ActionResult QuerytockChange()
        {
            return PartialView("_StockChange");
        }
    }
}



