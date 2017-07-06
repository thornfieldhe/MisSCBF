// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilCardProofListDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   加油卡消耗凭证单列表对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 加油卡消耗凭证单列表对象
    /// </summary>
    [AutoMap(typeof(OilCardProof))]
    public class OilCardProofListDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }        
        
        /// <summary>
        /// Month
        /// </summary>
        public string Month
        {
            get; set;
        }        
        
        /// <summary>
        /// BunkerACode
        /// </summary>
        public string BunkerACode
        {
            get; set;
        }        
        
        /// <summary>
        /// Date
        /// </summary>
        public string Date
        {
            get; set;
        }        
        
        /// <summary>
        /// Ss
        /// </summary>
        public decimal Ss
        {
            get; set;
        }        
        
        /// <summary>
        /// Msjg
        /// </summary>
        public decimal Msjg
        {
            get; set;
        }        
        
        /// <summary>
        /// CardNo
        /// </summary>
        public string CardNo
        {
            get; set;
        }        
        
        /// <summary>
        /// CarCode
        /// </summary>
        public string CarCode
        {
            get; set;
        }        
        
        /// <summary>
        /// Clxh
        /// </summary>
        public string Clxh
        {
            get; set;
        }        
        
        /// <summary>
        /// Cph
        /// </summary>
        public string Cph
        {
            get; set;
        }        
        
        /// <summary>
        /// Sy
        /// </summary>
        public string Sy
        {
            get; set;
        }        
        
        /// <summary>
        /// Yyje
        /// </summary>
        public decimal Yyje
        {
            get; set;
        }        
        
        /// <summary>
        /// Jyje
        /// </summary>
        public decimal Jyje
        {
            get; set;
        }        
        
        /// <summary>
        /// Syje
        /// </summary>
        public decimal Syje
        {
            get; set;
        }        
        
        /// <summary>
        /// Ylbh
        /// </summary>
        public string Ylbh
        {
            get; set;
        }        
        
        /// <summary>
        /// Jsy
        /// </summary>
        public decimal Jsy
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

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    } 
}



