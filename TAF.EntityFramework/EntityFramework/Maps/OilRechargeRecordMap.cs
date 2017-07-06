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
    public class OilRechargeRecordMap : EntityTypeConfiguration<OilRechargeRecord>
    {
        public OilRechargeRecordMap()
        {
            this.HasRequired(r => r.Octance).WithMany(r => r.OilRechargeRecords).HasForeignKey(r => r.OctanceId);
        }
    }
}