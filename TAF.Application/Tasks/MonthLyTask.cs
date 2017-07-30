// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonthlyTask.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   MonthlyTask
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Tasks
{

    using Abp.Dependency;
    using Abp.Quartz.Quartz;

    using Quartz;

    using SCBF.Car;

    /// <summary>
    /// 月度任务
    /// </summary>
    public class MonthlyTask : JobBase, ITransientDependency
    {
        public static readonly string Schedule = "59 30 23 L * ? ";//每月最后一天23:30:00

        private readonly IHisStoreStockAppService hisStoreStockAppService;

        public MonthlyTask(IHisStoreStockAppService hisStoreStockAppService)
        {
            this.hisStoreStockAppService = hisStoreStockAppService;
        }


        public override void Execute(IJobExecutionContext context)
        {
            this.hisStoreStockAppService.BackupData();
        }
    }
}