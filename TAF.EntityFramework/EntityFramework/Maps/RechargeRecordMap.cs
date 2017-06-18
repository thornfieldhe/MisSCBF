// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   EntryMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using SCBF.Car;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// 
    /// </summary>
    public class RechargeRecordMap : EntityTypeConfiguration<RechargeRecord>
    {
        public RechargeRecordMap()
        {
            this.HasRequired(r => r.OilCard).WithMany(r => r.RechargeRecords).HasForeignKey(r => r.OilCard);
        }
    }
}