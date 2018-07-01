// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   装备管理对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EquipObject.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 装备管理编辑对象
    /// </summary>
    [AutoMap(typeof(Equip))]
    public class EquipEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// LayerId
        /// </summary>
        public Guid LayerId
        {
            get; set;
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get; set;
        }

        /// <summary>
        /// Content
        /// </summary>
        public string Content
        {
            get; set;
        }
    }
}



