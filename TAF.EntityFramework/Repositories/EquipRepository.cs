// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.EquipObject;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 车辆维修耗时管理仓储
    /// </summary>
    public class EquipRepository : TAFRepositoryBase<Equip, Guid>, IEquipRepository
    {
        public EquipRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



