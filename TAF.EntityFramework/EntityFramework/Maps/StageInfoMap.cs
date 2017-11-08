// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StageInfoMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   StageInfoMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using System.Data.Entity.ModelConfiguration;
    using SCBF.Purchase;

    /// <summary>
    /// 项目阶段映射关系
    /// </summary>
    public class StageInfoMap : EntityTypeConfiguration<StageInfo>
    {
        public StageInfoMap()
        {
            this.HasRequired(r => r.ProcurementPlan).WithMany(r => r.StageInfos).HasForeignKey(r => r.ProcurementPlanId);
        }
    }
}