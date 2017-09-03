// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualOutlayMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ActualOutlayMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using System.Data.Entity.ModelConfiguration;

    using SCBF.Finance;

    /// <summary>
    /// 
    /// </summary>
    public class InvoiceMap : EntityTypeConfiguration<Invoice>
    {
        public InvoiceMap()
        {
            this.HasRequired(r => r.InvoiceCheck).WithMany(r => r.Invoices).HasForeignKey(r => r.InvoiceCheckId);
        }
    }
}