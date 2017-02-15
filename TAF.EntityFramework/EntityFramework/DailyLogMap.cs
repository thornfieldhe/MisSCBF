// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   DailyLogMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// 日志映射关系
    /// </summary>
    public class DailyLogMap : EntityTypeConfiguration<DailyLog>
    {
        public DailyLogMap()
        {
            this.HasRequired(t => t.Task).WithMany(t => t.DailyLogs).HasForeignKey(t => t.TaskId);
            this.HasRequired(t => t.ResponsiblePerson).WithMany(t => t.Logs).HasForeignKey(t => t.ResponsiblePersonId);
        }
    }
}