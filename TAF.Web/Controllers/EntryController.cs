﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库控制器
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
    /// 入库控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class EntryController : TAFControllerBase
    {
        private readonly IEntryAppService entryAppService;

        public EntryController(IEntryAppService entryAppService)
        {
            this.entryAppService = entryAppService;
        }
        
        public ActionResult EntryList()
        {
            var list = new List<KeyValue<string, Guid>>();
            return PartialView("_EntryIndex" ,list);
        }
    }
}



