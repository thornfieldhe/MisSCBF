﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServicingMaterialRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修审批单仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Car;
    
    /// <summary>
    /// 车辆维修审批单仓储接口
    /// </summary>
    public interface IServicingMaterialRepository : ITAFRepositoryBase<ServicingMaterial>
    {

    }
}



