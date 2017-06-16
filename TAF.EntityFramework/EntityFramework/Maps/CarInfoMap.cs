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
    public class CarInfoMap : EntityTypeConfiguration<CarInfo>
    {
        public CarInfoMap()
        {
            this.HasRequired(r => r.Clzk).WithMany(r => r.Cars).HasForeignKey(r => r.ClzkId);
        }
    }
}