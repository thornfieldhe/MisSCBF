// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   关系管理仓储
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;
    
    using SCBF.BaseInfo;
    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 关系管理仓储
    /// </summary>
    public class RelationshipRepository : TAFRepositoryBase<Relationship, Guid>, IRelationshipRepository
    {
        public RelationshipRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}



