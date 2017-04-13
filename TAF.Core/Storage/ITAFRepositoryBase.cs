// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SCBF.EntityFramework.Repositories.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ITAFRepositoryBase
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Abp.Domain.Repositories;

    public interface ITAFRepositoryBase<TEntity> : IRepository<TEntity, Guid> where TEntity : class, Abp.Domain.Entities.IEntity<Guid>
    {
        bool Any(Expression<Func<TEntity, bool>> func);

        bool All(Expression<Func<TEntity, bool>> func);

        void InsertRange(IEnumerable<TEntity> list);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> func);
    }
}