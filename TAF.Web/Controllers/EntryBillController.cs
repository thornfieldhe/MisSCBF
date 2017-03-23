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
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.Storage;
    using TAF.Utility;
    
    /// <summary>
    /// 入库单控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class EntryBillController : TAFControllerBase
    {
        private readonly IEntryBillAppService entryBillAppService;

        public EntryBillController(IEntryBillAppService entryBillAppService)
        {
            this.entryBillAppService = entryBillAppService;
        }
        
        public ActionResult EntryBillList()
        {
            var list = new List<KeyValue<string, Guid>>();
            return PartialView("_EntryBillIndex" ,list);
        }
    }
}



