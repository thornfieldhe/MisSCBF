// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ProductRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.EntityFramework;

    using SCBF.EntityFramework;
    using SCBF.EntityFramework.Repositories;

    /// <summary>
    /// 
    /// </summary>
    public class ProjectRepository : TAFRepositoryBase<Project, Guid>, IProjectRepository
    {
        public ProjectRepository(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}