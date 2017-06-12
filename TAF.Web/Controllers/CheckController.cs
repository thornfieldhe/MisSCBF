// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点控制器
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
    /// 盘点控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CheckController : TAFControllerBase
    {
        private readonly ICheckAppService checkAppService;

        public CheckController(ICheckAppService checkAppService)
        {
            this.checkAppService = checkAppService;
        }
        
        public ActionResult CheckList()
        {
            var list = new List<KeyValue<string, Guid>>();
            return PartialView("_CheckIndex" ,list);
        }
    }
}



