// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SysDictionaryEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo.Dto
{
    using Abp.AutoMapper;
    using System;

    /// <summary>
    /// 系统配置编辑对象
    /// </summary>
    [AutoMap(typeof(SysDictionary))]
    public class SysDictionaryEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Key
        /// </summary>
        public string Category
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value2
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value3
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value4
        {
            get; set;
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value5
        {
            get; set;
        }

        public string Value6
        {
            get; set;
        }

        public string Value7
        {
            get; set;
        }

        public string Value8
        {
            get; set;
        }

        public string Value9
        {
            get; set;
        }

        /// <summary>
        /// Value10
        /// </summary>
        public string Value10
        {
            get; set;
        }

        public string Value11
        {
            get; set;
        }

        public string Value12
        {
            get; set;
        }

        public string Value13
        {
            get; set;
        }

        public string Value14
        {
            get; set;
        }

        public string Value15
        {
            get; set;
        }

        public string Value16
        {
            get; set;
        }

        public string Value17
        {
            get; set;
        }

        public string Value18
        {
            get; set;
        }

        public string Value19
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



