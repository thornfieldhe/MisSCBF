// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Abp.AutoMapper;

namespace SCBF.Finance.Dto
{
	/// <summary>
    /// 发票录入编辑对象
    /// </summary>
    [AutoMap(typeof(InvoiceCheck))]
    public class InvoiceCheckEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id
        {
            get; set;
        }        
        
        /// <summary>
        /// From
        /// </summary>
        public long From
        {
            get; set;
        }        
        
        /// <summary>
        /// To
        /// </summary>
        public long? To
        {
            get; set;
        }        
    } 
}



