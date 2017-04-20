using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;

namespace SCBF.Web
{
    using SCBF.EntityFramework;
    using SCBF.Migrations.SeedData;

    public class MvcApplication : AbpWebApplication<TAFWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {

            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config"));

            base.Application_Start(sender, e);

            //            using (var context = new TAFDbContext())
            //            {
            //                new DefaultEditionsCreator(context);
            //                new DefaultLanguagesCreator(context);
            //                new DefaultRolesCreator(context);
            //                new DefaultRolePermissionCreator(context);
            //                new HostRoleAndUserCreator(context);
            //                new DefaultSettingsCreator(context);
            //            }
        }
    }
}
