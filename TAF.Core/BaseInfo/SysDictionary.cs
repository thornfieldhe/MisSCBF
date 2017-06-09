// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dictionary.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统字典表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using SCBF.Storage;
    using System.Collections.Generic;

    /// <summary>
    /// 系统字典表
    /// </summary>
    public class SysDictionary : TAFEntity
    {
        public string Value
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

        public string Value2
        {
            get; set;
        }

        public string Value3
        {
            get; set;
        }

        public string Value4
        {
            get; set;
        }

        /// <summary>
        /// Value5
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

        public virtual List<Entry> Entries
        {
            get; set;
        }

        public virtual List<Delivery> Deliveries
        {
            get; set;
        }

        public virtual List<Stock> Stocks
        {
            get; set;
        }

        public virtual List<HisStock> HisStocks
        {
            get; set;
        }
    }
}