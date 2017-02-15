// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultCreator.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   基础种子模块
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Migrations.SeedData
{
    using SCBF.EntityFramework;

    /// <summary>
    /// 基础种子模块
    /// </summary>
    public abstract class DefaultCreator
    {
        protected readonly TAFDbContext Context;

        protected DefaultCreator(TAFDbContext context)
        {
            this.Context = context;
        }

        public abstract void Create();
    }
}