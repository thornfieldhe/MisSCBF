// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeYearTask.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ChangeYearTask
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Tasks
{

    using Abp.Dependency;
    using Abp.Quartz.Quartz;

    using Quartz;

    using SCBF.Storage;

    /// <summary>
    /// 每日更新当日库存
    /// </summary>
    public class DailyTask : JobBase, ITransientDependency
    {
        public static readonly string Schedule = "59 40 23 * * ? ";//每日23:40:00

        private readonly IHisStockAppService hisStockAppService;

        public DailyTask(IHisStockAppService hisStockAppService)
        {
            this.hisStockAppService = hisStockAppService;
        }


        public override void Execute(IJobExecutionContext context)
        {
            hisStockAppService.BackupData();
        }
    }
}