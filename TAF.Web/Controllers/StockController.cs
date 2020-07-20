// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StockController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   库存控制器
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
    /// 库存控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class StockController : TAFControllerBase
    {
        private readonly IStockAppService stockAppService;

        public StockController(IStockAppService stockAppService)
        {
            this.stockAppService = stockAppService;
        }
        
        public ActionResult StockList()
        {
            var list = new List<KeyValue<string, Guid>>();
            return PartialView("_StockIndex" ,list);
        }
        
        
        public FileResult DownloadStock()
        {
            var file =  this.stockAppService.ExportExs();
            return    this.DownloadFile(file);
        }
    }
}



