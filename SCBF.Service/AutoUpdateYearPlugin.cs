// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoUpdateYearPlugin.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   AutoUpdateYearPlugin
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Service
{
    using System;
    using System.Collections.Generic;

    using Quartz;

    using SCBF.BaseInfo;

    /// <summary>
    /// 
    /// </summary>
    public class AutoUpdateYearPlugin : IWinServicePlugin
    {
        private readonly ISysDictionaryAppService sysDictionaryAppService;
        public AutoUpdateYearPlugin(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }

        public bool Start()
        {
            var r = this.sysDictionaryAppService.GetSimpleList();
            foreach (var dto in r)
            {
                Console.WriteLine(dto.Value);
            }
            return true;
            
        }

        public bool Stop() { throw new System.NotImplementedException(); }


        public string Name { get { return "年初定时生成新的预算年度"; } }

        public void Execute(IJobExecutionContext context)
        {
            throw new System.NotImplementedException();

        }
    }
}