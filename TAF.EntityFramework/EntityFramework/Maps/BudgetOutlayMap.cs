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
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;

    using SCBF.Finance;

    /// <summary>
    /// 
    /// </summary>
    public class BudgetOutlayMap : EntityTypeConfiguration<BudgetOutlay>
    {
        public BudgetOutlayMap()
        {
            this.HasOptional(r => r.BudgetReceipt).WithMany(r => r.BudgetOutlaies).HasForeignKey(r => r.ReceiptId);
        }
    }
}