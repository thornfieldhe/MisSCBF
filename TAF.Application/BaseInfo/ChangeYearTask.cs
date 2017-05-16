// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeYearTask.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ChangeYearTask
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Collections.Generic;

    using Abp.Dependency;

    using Castle.Core.Logging;

    using Quartz;

    /// <summary>
    /// 
    /// </summary>
    public class ChangeYearTask : IJob, ITransientDependency
    {
        private readonly ILogger logger;
        public ChangeYearTask(ILogger logger) {
            this.logger = logger;
        }

        
        public void Execute(IJobExecutionContext context)
        {
            logger.Info($"当前时间:{DateTime.Now}");
            
        }
    }
}