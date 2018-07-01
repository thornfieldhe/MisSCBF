// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarRepairTimeController.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理控制器
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Abp.Web.Mvc.Authorization;
    
    using SCBF.Car;
    using TAF.Utility;
    
    /// <summary>
    /// 车辆维修耗时管理控制器
    /// </summary>
    [AbpMvcAuthorize]
    public class CarRepairTimeController : TAFControllerBase
    {
        private readonly ICarRepairTimeAppService _carRepairTimeAppService;

        public CarRepairTimeController(ICarRepairTimeAppService carRepairTimeAppService)
        {
            this._carRepairTimeAppService = carRepairTimeAppService;
        }
        
        public ActionResult CarRepairTimeList()
        {
            ViewData["list1"] = new List<KeyValue<string, Guid>>();
            return PartialView("_CarRepairTimeIndex");
        }
    }
}



