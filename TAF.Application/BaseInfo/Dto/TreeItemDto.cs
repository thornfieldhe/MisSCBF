// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeItemDto.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   TreeItemDto
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Layer))]
    public class TreeItemDto
    {
        public string Name
        {
            get; set;
        }

        public Guid Id
        {
            get; set;
        }

        public Guid PId
        {
            get; set;
        }

        public string LevelCode
        {
            get; set;
        }

    }
}