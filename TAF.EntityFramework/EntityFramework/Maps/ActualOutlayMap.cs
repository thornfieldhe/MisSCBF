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
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;

    using SCBF.Finance;

    /// <summary>
    /// 
    /// </summary>
    public class ActualOutlayMap : EntityTypeConfiguration<ActualOutlay>
    {
        public ActualOutlayMap()
        {
            this.HasOptional(r => r.Outlay).WithMany(r => r.ActualOutlays).HasForeignKey(r => r.OutlayId);
        }
    }
}