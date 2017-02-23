// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LayerListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 商品类别列表对象
    /// </summary>
    [AutoMap(typeof(Layer))]
    public class LayerListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// PId
        /// </summary>
        public Guid? PId
        {
            get; set;
        }

        /// <summary>
        /// PName
        /// </summary>
        public string PName
        {
            get; set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Order
        /// </summary>
        public int Order
        {
            get; set;
        }

        /// <summary>
        /// Note
        /// </summary>
        public string Note
        {
            get; set;
        }

    }
}



