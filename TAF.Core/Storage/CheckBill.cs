// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBill.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   CheckBill
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     盘点表
    /// </summary>
    public class CheckBill : TAFEntity
    {
        public DateTime Date { get; set; }

        public string Code { get; set; }

        public virtual List<Check> Checks { get; set; }

        /// <summary>
        ///     Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 仓库Id
        /// </summary>
        public Guid StorageId
        {
            get; set;
        }

    }
}