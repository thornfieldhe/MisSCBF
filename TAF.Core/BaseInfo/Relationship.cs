// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Relationship.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   关联表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;

    /// <summary>
    /// 关联表
    /// </summary>
    public class Relationship:TAFEntity
    {
        public Guid  PrincipalKey{ get; set; }

        public Guid ForeignKey { get; set; }

        public string Type { get; set; }
    }
}
