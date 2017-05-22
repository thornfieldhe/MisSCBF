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

    using Castle.Core.Logging;

    using Quartz;

    /// <summary>
    /// 每日更新当日库存
    /// </summary>
    public class DailyStoreTask : JobBase, ITransientDependency
    {
        private readonly IHisStockAppService hisStockAppService;
        public DailyStoreTask(IHisStockAppService hisStockAppService)
        {
            this.hisStockAppService = hisStockAppService;
        }


        public override void Execute(IJobExecutionContext context)
        {
            hisStockAppService.BackupData();
        }

        public static readonly string Schedule = "0 0 23 * * ? *";//每日23:00分执行
    }

}