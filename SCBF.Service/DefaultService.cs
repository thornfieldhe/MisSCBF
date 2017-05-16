// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   DefaultService
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Service
{
    using Abp.Dependency;
    using SCBF.BaseInfo;
    using System;
    using System.Collections.Generic;
    using Topshelf;

    /// <summary>
    /// 
    /// </summary>
    public class DefaultService : ServiceControl, ITransientDependency
    {
        private readonly List<IWinServicePlugin> plugins = new List<IWinServicePlugin>();
        private readonly IIocResolver iocResolver = IocManager.Instance;

        public DefaultService()
        {
            
            this.plugins.Add(new AutoUpdateYearPlugin(iocResolver.Resolve<SysDictionaryAppService>()));
        }

        public bool Start(HostControl hostControl)
        {
            foreach (var plugin in this.plugins)
            {
                plugin.Start();
                Console.WriteLine($"插件[{plugin.Name}]启动成功");
            }
            Console.WriteLine($"服务启动成功");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            foreach (var plugin in this.plugins)
            {
                plugin.Stop();
                Console.WriteLine($"插件[{plugin.Name}]停止成功");
            }
            Console.WriteLine($"服务停止成功");
            return true;
        }
    }
}