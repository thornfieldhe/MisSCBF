// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDriverRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   驾驶员仓储接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;
    
    using SCBF.Car;
    
    /// <summary>
    /// 驾驶员仓储接口
    /// </summary>
    public interface IDriverRepository : ITAFRepositoryBase<Driver>
    {

    }
}



