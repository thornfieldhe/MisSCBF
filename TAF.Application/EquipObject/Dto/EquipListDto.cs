// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   车辆维修耗时管理列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EquipObject.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 车辆维修耗时管理列表对象
    /// </summary>
    [AutoMap(typeof(Equip))]
    public class EquipListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
        /// <summary>
        /// LayerName
        /// </summary>
        public string LayerName
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



