// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DriverEditDto.cs" company=""  author="何翔华">
//   
// </copyright>
// <summary>
//   驾驶员编辑对象
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car.Dto
{
    using System;

    using Abp.AutoMapper;

    /// <summary>
    /// 驾驶员编辑对象
    /// </summary>
    [AutoMap(typeof(Driver))]
    public class DriverEditDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
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
        /// SoldierId
        /// </summary>
        public string SoldierId
        {
            get; set;
        }        
        
        /// <summary>
        /// ValidDrivingLicense
        /// </summary>
        public string ValidDrivingLicense
        {
            get; set;
        }  
        
        /// <summary>
        /// DrivingLicense
        /// </summary>
        public string DrivingLicense
        {
            get; set;
        }        
        
        /// <summary>
        /// Level
        /// </summary>
        public Guid Level
        {
            get; set;
        }        
        
        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber
        {
            get; set;
        }        
    } 
}



