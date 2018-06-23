// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EqManagerEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   会质量评价体系编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 会质量评价体系编辑对象
    /// </summary>
    [AutoMap(typeof(EqManager))]
    public class EqManagerEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }

        /// <summary>
        /// PlanId
        /// </summary>
        public Guid PlanId
        {
            get; set;
        }

        /// <summary>
        /// Unit1
        /// </summary>
        public Guid? Unit1
        {
            get; set;
        }

        /// <summary>
        /// Score1
        /// </summary>
        public decimal? Score1
        {
            get; set;
        }

        /// <summary>
        /// Unit2
        /// </summary>
        public Guid? Unit2
        {
            get; set;
        }

        /// <summary>
        /// Score2
        /// </summary>
        public decimal? Score2
        {
            get; set;
        }

        /// <summary>
        /// Unit3
        /// </summary>
        public Guid? Unit3
        {
            get; set;
        }

        /// <summary>
        /// Score3
        /// </summary>
        public decimal? Score3
        {
            get; set;
        }

        /// <summary>
        /// Unit4
        /// </summary>
        public Guid? Unit4
        {
            get; set;
        }

        /// <summary>
        /// Score4
        /// </summary>
        public decimal? Score4
        {
            get; set;
        }

        /// <summary>
        /// Unit5
        /// </summary>
        public string Unit5
        {
            get; set;
        }

        /// <summary>
        /// Score5
        /// </summary>
        public decimal? Score5
        {
            get; set;
        }


        /// <summary>
        /// UnitName1
        /// </summary>
        public string UnitName1
        {
            get; set;
        }

        /// <summary>
        /// UnitName1
        /// </summary>
        public string UnitName2
        {
            get; set;
        }

        /// <summary>
        /// UnitName1
        /// </summary>
        public string UnitName3
        {
            get; set;
        }

        /// <summary>
        /// UnitName1
        /// </summary>
        public string UnitName4
        {
            get; set;
        }

    }
}



