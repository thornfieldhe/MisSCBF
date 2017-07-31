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
    public class HisOilStockController : TAFControllerBase
    {

        public HisOilStockController()
        {
        }

        public ActionResult TotalOilHisList()
        {
            return PartialView("_TotalOilHisList");
        }

    }
}



