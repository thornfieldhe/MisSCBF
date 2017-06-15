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
    using Abp.Dependency;
    using Abp.Quartz.Quartz;
    using Quartz;
    using SCBF.BaseInfo.Dto;
    using System;

    /// <summary>
    /// 物资管理模块年底更新期末数据
    /// </summary>
    public class ChangeYearTask : JobBase, ITransientDependency
    {
        public static readonly string Schedule = "0 0 1 1 1 ?"; //每年1月1日1:00执行

        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public ChangeYearTask(ISysDictionaryAppService sysDictionaryAppService)
        {
            this.sysDictionaryAppService = sysDictionaryAppService;
        }


        public override void Execute(IJobExecutionContext context)
        {
            var t = DateTime.Today.Year.ToString();

            sysDictionaryAppService.SaveYearAsync(
                new SysDictionaryEditDto()
                {
                    Category = DictionaryCategory.Material_Year,
                    Value = t
                });

            sysDictionaryAppService.SaveYearAsync(
                new SysDictionaryEditDto()
                {
                    Category = DictionaryCategory.Car_Year,
                    Value = t
                });
        }
    }
}