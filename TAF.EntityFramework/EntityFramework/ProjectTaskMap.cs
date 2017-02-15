// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTaskMap.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ProductTaskMap
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EntityFramework
{
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// 项目映射关系
    /// </summary>
    public class ProjectTaskMap : EntityTypeConfiguration<ProjectTask>
    {
        public ProjectTaskMap()
        {
            this.HasRequired(d => d.Project).WithMany(t => t.Tasks).HasForeignKey(t => t.ProjectId);
        }
    }
}