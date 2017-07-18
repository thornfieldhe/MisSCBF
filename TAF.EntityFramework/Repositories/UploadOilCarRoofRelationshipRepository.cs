// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadOilCarRoofRelationshipRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单单仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.Car;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 加油卡消耗凭证单单仓储
    /// </summary>
    public class UploadOilCarRoofRelationshipRepository : TAFRepositoryBase<UploadOilCarRoofRelationship, Guid>, IUploadOilCarRoofRelationshipRepository
    {
        public UploadOilCarRoofRelationshipRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



