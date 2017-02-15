using System.Reflection;
using System.Web.Http;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace SCBF.Api
{
    using Abp.Application.Services;

    [DependsOn(typeof(AbpWebApiModule), typeof(TAFApplicationModule))]
    public class TAFWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(TAFApplicationModule).Assembly, "app")
                .Build();
            //            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            //             .For<ITaskAppService>("app/task").Build();
            //            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            //            .For<IUserAppService>("app/user").Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
