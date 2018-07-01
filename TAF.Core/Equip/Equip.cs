// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Equip.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   装备对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EquipObject
{
    using System;

    /// <summary>
    /// 装备对象
    /// </summary>
    public class Equip : TAFEntity
    {
        /// <summary>
        /// 对应层次结构Id
        /// </summary>
        public Guid LayerId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
