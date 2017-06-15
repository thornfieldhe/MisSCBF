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
    public class DriverMap : EntityTypeConfiguration<Driver>
    {
        public DriverMap()
        {
            this.HasRequired(r => r.Level).WithMany(r => r.Drivers).HasForeignKey(r => r.LevelId);
        }
    }
}