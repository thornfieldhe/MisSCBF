// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTaskCreator.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ScheduledTaskCreator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Migrations.SeedData
{
    using System.Collections.Generic;
    using System.Linq;

    using SCBF.BaseInfo;
    using SCBF.EntityFramework;

    /// <summary>
    /// 
    /// </summary>
    public class ScheduledTaskCreator : DefaultCreator
    {
        public ScheduledTaskCreator(TAFDbContext context) : base(context)
        {
        }

        public override void Create()
        {
            if (!this.Context.ScheduledTasks.Any())
            {
                this.Context.ScheduledTasks.Add(
                    new ScheduledTask() { Name = "物资管理模块年底更新期末数据", Started = false, Schedule = "* 60 22 31 12 ? *" });//每年12月31日22:00分执行
                this.Context.ScheduledTasks.Add(
                    new ScheduledTask() { Name = "每日更新当日库存", Started = false, Schedule = "* 30 23 * ? ? " });//每日23:30分执行
                this.Context.SaveChanges();
            }

        }
    }
}