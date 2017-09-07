// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Yearly.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Yearly
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Tasks
{
    using System;
    using Abp.Dependency;
    using Abp.Quartz.Quartz;
    using Quartz;
    using SCBF.BaseInfo;
    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 年度任务:物资管理模块年底更新期末数据
    /// </summary>
    public class Yearly : JobBase, ITransientDependency
    {
        public static readonly string Schedule = "0 0 1 1 1 ?"; //每年1月1日1:00执行

        private readonly ISysDictionaryAppService sysDictionaryAppService;

        public Yearly(ISysDictionaryAppService sysDictionaryAppService)
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

            sysDictionaryAppService.SaveYearAsync(
                new SysDictionaryEditDto()
                {
                    Category = DictionaryCategory.Purchase_Year,
                    Value = t
                });
        }
    }
}