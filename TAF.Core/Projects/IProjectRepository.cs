// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   IProductRepository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    using Abp.Domain.Repositories;

    /// <summary>
    /// 
    /// </summary>
    public interface IProjectRepository : IRepository<Project, Guid>
    {

    }
}