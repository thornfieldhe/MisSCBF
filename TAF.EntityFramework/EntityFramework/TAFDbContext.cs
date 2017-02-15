using System.Data.Common;
using Abp.Zero.EntityFramework;

namespace SCBF.EntityFramework
{
    using System.Data.Entity;

    using SCBF.Authorization.Roles;
    using SCBF.Dictionary;
    using SCBF.MultiTenancy;
    using SCBF.Users;

    public class TAFDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public TAFDbContext()
            : base("Default") { }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TAFDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TAFDbContext since ABP automatically handles it.
         */

        public TAFDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        //This constructor is used in tests
        public TAFDbContext(DbConnection connection)
            : base(connection, true) { }

        public DbSet<Project> Project
        {
            get; set;
        }

        public DbSet<ProjectTask> ProjectTask
        {
            get; set;
        }

        public DbSet<DailyLog> DailyLog
        {
            get; set;
        }

        public DbSet<SysDictionary> Dictionary
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectTaskMap());
            modelBuilder.Configurations.Add(new DailyLogMap());
            base.OnModelCreating(modelBuilder);

        }
    }

}
