// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeYearTask.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ChangeYearTask
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using SCBF.Car;
using SCBF.Purchase;

namespace SCBF.Tasks
{

    using Abp.Dependency;
    using Abp.Quartz.Quartz;

    using Quartz;

    using Storage;

    /// <summary>
    /// 每日更新当日库存
    /// </summary>
    public class DailyTask : JobBase, ITransientDependency
    {
        public static readonly string Schedule = "59 40 23 * * ? ";//每日23:40:00

        private readonly IHisStockAppService _hisStockAppService;
        private readonly ICarInfoAppService _carInfoAppService;
        private readonly IBlacklistAppService _blacklistAppService;

        public DailyTask(IHisStockAppService hisStockAppService,
            ICarInfoAppService carInfoAppService,
            IBlacklistAppService blacklistAppService)
        {
            this._hisStockAppService = hisStockAppService;
            this._carInfoAppService = carInfoAppService;
            this._blacklistAppService = blacklistAppService;
        }


        public override void Execute(IJobExecutionContext context)
        {
            this._hisStockAppService.BackupData();
            this._carInfoAppService.ModifyStatus();
            this._blacklistAppService.RemoveFromList();
        }
    }
}