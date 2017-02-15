using System.Data.Entity;
using System.Reflection;
using Abp.Modules;

namespace SCBF.Migrator
{
    using SCBF.EntityFramework;

    [DependsOn(typeof(TAFDataModule))]
    public class TAFMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TAFDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}