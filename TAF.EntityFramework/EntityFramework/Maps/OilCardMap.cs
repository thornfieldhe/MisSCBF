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
    public class OilCardMap : EntityTypeConfiguration<OilCard>
    {
        public OilCardMap()
        {
            this.HasRequired(r => r.CarInfo).WithMany(r => r.OilCards).HasForeignKey(r => r.CarInfoId);
        }
    }
}