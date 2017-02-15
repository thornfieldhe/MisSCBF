using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace SCBF.EntityFramework.Repositories
{
    public abstract class TAFRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TAFDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TAFRepositoryBase(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TAFRepositoryBase<TEntity> : TAFRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected TAFRepositoryBase(IDbContextProvider<TAFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
