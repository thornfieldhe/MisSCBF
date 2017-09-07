// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlayMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   BudgetOutlayMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using System.Data.Entity.ModelConfiguration;
    using SCBF.Purchase;

    /// <summary>
    /// 
    /// </summary>
    public class PlanWithBudgetOutlayMap : EntityTypeConfiguration<PlanWithBudgetOutlay>
    {
        public PlanWithBudgetOutlayMap()
        {
            this.HasOptional(r => r.BudgetOutlay).WithMany(r => r.PlanWithBudgetOutlays).HasForeignKey(r => r.BudgetOutlayId);
            this.HasOptional(r => r.ProcurementPlan).WithMany(r => r.PlanWithBudgetOutlays).HasForeignKey(r => r.ProcurementPlanId);
        }
    }
}