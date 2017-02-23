// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Layer.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Layer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Layer : TAFEntity
    {
        /// <summary>
        /// 父Id
        /// </summary>
        public Guid? PId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public int Order
        {
            get; set;
        }

        /// <summary>
        /// 层级
        /// </summary>
        public int Level
        {
            get; set;
        }

        /// <summary>
        /// 层级编码
        /// </summary>
        public string LevelCode
        {
            get; set;
        }

        public string Note
        {
            get; set;
        }

        public string Category
        {
            get; set;
        }
    }
}